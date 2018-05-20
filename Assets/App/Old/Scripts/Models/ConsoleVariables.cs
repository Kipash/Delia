using UnityEngine;
using System.Collections;
using AppBackend;

namespace Skyrise
{
    public class ConsoleVariables
    {
        //public string UserName { get; set; }

        public string UserDataPath
        {
            get
            {
                return DataStorage.UserPath;
            }
        }

        public string UserName
        {
            get
            {
                return DataStorage.UserData.UserName;
            }
            set
            {
                DataStorage.UserData.UserName = value;
                DataStorage.SaveUserData();
            }
        }

        public int Money
        {
            get
            {
                return DataStorage.UserData.Money;
            }
            set
            {
                DataStorage.UserData.Money = value;
                DataStorage.SaveUserData();
            }
        }
        public string Time  
        {
            get
            {
                return DataStorage.UserData.Time;
            }
            set
            {
                DataStorage.UserData.Time = value.Replace('_', ' ');
                DataStorage.SaveUserData();
            }
        }
    }
}