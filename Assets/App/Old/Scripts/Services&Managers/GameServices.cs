using UnityEngine;
using System.Collections;
using System;
using AppBackend;

namespace Skyrise
{
    public class GameServices : MonoBehaviour
    {
        /*
        static GameServices instance;
        public static GameServices Instance { get { return instance; } }

        [Header("Services")]

        public DayNightCycle DayNightCycle;

        public BlockManager BlockManager;

        [HideInInspector]
        public UIGameManager UI;

        [Header("References")]
        [SerializeField] GameObject uiGO;

        void Awake()
        {
            var t = DateTime.Now;

            if (SetupInstance() && AppServices.Instance != null)
            {
                try
                {
                    InitializeServices();
                }
                catch(Exception e)
                {
                    Debug.LogError(e.Message);
                    Debug.LogError(e.StackTrace);
                }

                var diff = (DateTime.Now - t);
                Debug.Log(string.Format("All Game services loaded in {0} ms ({1} tics)", diff.TotalMilliseconds, diff.Ticks));

                //Log.Console.Add("st", this, "SaveTime");
            }
        }

        private void OnApplicationQuit()
        {
            if (Instance != null && AppServices.Instance != null)
            {
                print("saving");
                SaveTime();
            }
        }
        

        public void SaveTime()
        {
            DataStorage.UserData.Time = DayNightCycle.GetDateTime();
            DataStorage.SaveUserData();
        }

        void Start()
        {
            SetInitialUIValues();
        }
        void InitializeServices()
        {
            if (!GetUIMangerInstance())
                Debug.LogError("Can't set UIGameManager instace");
            DayNightCycle.Setup(DataStorage.UserData.Time);
            UI.Initialize();
        }

        bool GetUIMangerInstance()
        {
            if (uiGO != null)
            {
                UIGameManager instance = uiGO.GetComponent<UIGameManager>();
                if (instance != null)
                {
                    UI = instance;
                    return true;
                }
            }
            return false;
        }

        bool SetupInstance()
        {
            if (instance == null)
                instance = this;
            else if (instance.gameObject != null)
            {
                Destroy(gameObject);
                Debug.LogError("GameServices: multiple instances detected");
                return false;
            }
            else
                instance = this;

            return true;
        }

        void SetInitialUIValues()
        {
            UI.SetMoney(DataStorage.UserData.Money);
        }
        */
    }
}