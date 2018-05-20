using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AppBackend
{
    public static class DataStorage
    {
        public static string UserPath { get; private set; }
        //static string programPath;

        public static UserData UserData { get; private set; }
        
        //public static ProgramData ProgramData { get; private set; }
        
        public static void Load(string path)
        {

            UserPath = path;
            UserData = LoadUserData();

            /*
            programPath = cfg.ProgramDataPath;
            ProgramData = LoadProgramData();
            */
        }
        public static void SaveUserData()
        {
            if (UserData == null)
                throw new NullReferenceException("UserData cannot be null");

            Save(UserPath, UserData);
        }

        static UserData LoadUserData()
        {
            var data = LoadFromFile<UserData>(UserPath);

            if (data == null)
                data = new UserData();
            if (data.UserName == null)
                data.UserName = "DefaultPlayer";
            if (data.Time == "" || data.Time == null)
                data.Time = "01/01/0001 00:00:01";


            return data;
        }
        /*
        static ProgramData LoadProgramData()
        {
            var data = LoadFromFile<ProgramData>(programPath);

            if (data == null)
                data = new ProgramData();
            
            
            return data;
        }
        */
        static void Save<T>(string path, T obj) where T : class, new()
        {
            using (var sw = new StreamWriter(path))
            {
                var xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, obj);
            }
        }
        static T LoadFromFile<T>(string path) where T : class, new()
        {
            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path))
                {
                    var xs = new XmlSerializer(typeof(T));
                    return (T)xs.Deserialize(sr);
                }
            }
            return new T();
        }
        static T LoadFromText<T>(string value) where T : class, new()
        {
            if (!string.IsNullOrEmpty(value))
            {
                using (var sr = new MemoryStream(Encoding.UTF8.GetBytes(value)))
                {
                    var xs = new XmlSerializer(typeof(T));
                    return (T)xs.Deserialize(sr);
                }
            }
            return new T();
        }
    }
}
