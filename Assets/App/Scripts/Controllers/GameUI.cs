using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Zenject;
using System;

namespace PROJECT_HUSKY
{
    public class GameUI : IInitializable
    {
        [Inject] OnTimeChanged onTimeChanged;
        [Inject] OnDateChanged OnDateChanged;

        [Inject(Id = "timeUI")] Text timeText;
        [Inject(Id = "dateUI")] Text dateText;

        public void Initialize()
        {
            onTimeChanged.Listen(UpdateTime);
            OnDateChanged.Listen(UpdateDate);
        }

        void UpdateTime(int h, int m, int s)
        {
            timeText.text = $"{h.ToString("D2")}:{m.ToString("D2")}:{s.ToString("D2")}";
        }
        void UpdateDate(int y, int m, int d)
        {
            Debug.Log("date updated!");
            dateText.text = $"{y.ToString("D4")}/{m.ToString("D2")}/{d.ToString("D2")}"; 
        }
    }
}
