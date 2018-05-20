using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using System.IO;

namespace AppBackend
{
    [CreateAssetMenu(fileName = "Data files", menuName = "Configs/DataFiles", order = 1)]
    public class FileConfig : ScriptableObject
    {
        string userDataPath;
        public string UserDataPath
        {
            get
            {
                if (string.IsNullOrEmpty(userDataPath))
                    SetUserDataPath();
                return userDataPath;
            }
        }
        public string ProgramDataPath;

        void SetUserDataPath()
        {
            if (!string.IsNullOrEmpty(userDataPath))
                return;

            userDataPath = Application.persistentDataPath + "/userdata";

            if (SystemInfo.operatingSystem != null && SystemInfo.operatingSystem.StartsWith("Windows") &&
                !string.IsNullOrEmpty(Environment.CommandLine))
            {
                var idArg = Regex.Match(Environment.CommandLine, @"--id=(\w+)");
                if (idArg.Success)
                    userDataPath += "-" + idArg.Groups[1].Value;
            }

        }

        public void DeleteUserData()
        {
            SetUserDataPath();

            if (File.Exists(userDataPath))
                File.Delete(userDataPath);
        }
    }
}
