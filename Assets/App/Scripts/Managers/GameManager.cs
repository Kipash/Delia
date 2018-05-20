using UnityEngine;
using System.Collections;
using Zenject;
namespace PROJECT_HUSKY
{
    public class GameManager : IInitializable
    {
        TimeManager timeManager;

        public GameManager(TimeManager timeManager)
        {
            this.timeManager = timeManager;
        }

        public void Initialize()
        {
            timeManager.Speed = 100;
            timeManager.Paused = false;
        }
    }
}