using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.IO;

namespace Tests.Backend
{
    public class DataStorage
    {

        [Test, Order(0)]
        public void Save()
        {
            Load(); //Loading defaults, saving the path
            AppBackend.DataStorage.SaveUserData();
            Assert.IsTrue(File.Exists(Application.persistentDataPath + "/userdata"));
        }
        [Test, Order(1)]
        public void Load()
        {
            AppBackend.DataStorage.Load(Application.persistentDataPath + "/userdata");
            Assert.NotNull(AppBackend.DataStorage.UserData);
        }
    }
}