using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using Zenject;
using System;

namespace PROJECT_HUSKY
{
    public class TimeManager : ITickable
    { 
        DateTime time;

        public bool Paused { get; set; }


        [Inject] OnTimeChanged onTimeChanged { get; set; }
        [Inject] OnDateChanged onDateChanged { get; set; }
        [Inject] OnNewHour onNewHour { get; set; }

        double newSecondStamp;
        double newHourStamp;
        double newDayStamp;

        int speed;
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = Mathf.Clamp(value, 1, 999);
            }
        }

        public TimeManager()
        {
            time = new DateTime(1);

            Debug.Log("TimeManager initialized");
        }

        void Cycle()
        {
            AddTime();
            CheckForEvents();
        }
        void CheckForEvents()
        {
            double currMS = GetTotalMiliseconds(time);
            if (currMS > newSecondStamp)
            {
                newSecondStamp = currMS + 1000;
                onTimeChanged.Fire(time.Hour, time.Minute, time.Second);
            }
            if (currMS > newHourStamp)
            {
                newHourStamp = currMS + (1000 * 60 * 60);
                onNewHour.Fire();
            }
            if (currMS > newDayStamp)
            {
                newDayStamp = currMS + (1000 * 60 * 60 * 24);
                onDateChanged.Fire(time.Year, time.Month, time.Day);
            }
        }
        void AddTime()
        {
            double timeToAdd = Time.deltaTime * 12 * Speed * 1000;
            time = time.AddMilliseconds(timeToAdd);
        }
        double GetTotalMiliseconds(DateTime t)
        {
            return  (t.Day * 24 * 60 * 60 * 1000) +
                    (t.Hour * 60 * 60 * 1000) +
                    (t.Minute * 60 * 1000) +
                    (t.Second * 1000) +
                    (t.Millisecond);
        }
        public void Tick()
        {
            Cycle();
        }

    }

}