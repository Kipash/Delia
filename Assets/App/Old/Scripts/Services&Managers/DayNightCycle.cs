using UnityEngine;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace Skyrise
{
    [Serializable]
    public class DayNightCycle
    {
        /*
        public Action OnNewHour;

        [SerializeField] int defaultTime;
        [SerializeField] float timeScale;
        [SerializeField] float debugTimeScale = 1;

        [SerializeField] Transform light;
        public DateTime time { get; private set; }
        DateTime temp = new DateTime();
        public void Setup(string rawTime)
        {
            if(!DateTime.TryParseExact(rawTime, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out temp))
            {
                time = DateTime.Now;
            }
            else
            {
                time = temp;
            }

            GameServices.Instance.UI.SetTime(time);
            GameServices.Instance.UI.SetDate(time);
            Loop();
        }

        async void Loop()
        {
            while(true)
            {
                time = time.AddSeconds(1);
                
                if(time.Minute == 0 && time.Second == 0)
                {
                    OnNewHour?.Invoke();

                    if(time.Hour == 0)
                    {
                        GameServices.Instance.UI.SetDate(time);
                    }
                }

                GameServices.Instance.UI.SetTime(time);

                await Task.Delay(TimeSpan.FromMilliseconds(1000 / (timeScale * debugTimeScale)));

                AdjustRotation();
            }
        }
        void AdjustRotation()
        {
            int day = 24*60*60; //=360°
            int seconds = (time.Hour * 60 * 60) + (time.Minute * 60) + time.Second;
            float angle = ((seconds / day) * 360) - 115f;
            
            light.transform.localRotation = Quaternion.Euler(angle, 0, 0);
        }

        public string GetDateTime()
        {
            return (time.Day < 10 ? "0" + time.Day : time.Day.ToString()) + "/" +
                   (time.Month < 10 ? "0" + time.Month : time.Month.ToString()) + "/" +
                   "0000".Substring(time.Year.ToString().Length) + time.Year.ToString() +
                    " " +
                   (time.Hour < 10 ? "0" + time.Hour : time.Hour.ToString()) + ":" +
                   (time.Minute < 10 ? "0" + time.Minute : time.Minute.ToString()) + ":" +
                   (time.Second < 10 ? "0" + time.Second : time.Second.ToString());
        }
        */
    }
}