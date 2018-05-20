using System;
using System.Collections;
using System.Collections.Generic;
using AppBackend;
using System.Reflection;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[assembly:AssemblyVersion ("1.1.*")]
namespace Skyrise
{
    public class AppServices : MonoBehaviour
    {
        static AppServices instance;
        public static AppServices Instance
        {
            get
            {
                return instance;
            }
        }

        /*
        [Header("- Data -")]
        public FileConfig fileConfig;
        */

        [Header("- Services -")]
        public AppUIManager AppUI;
        //public ConsoleInput ConsoleManger;
        public SceneManager SceneManager;
        public CVarManager cVarManager;
        public AppInput AppInput;
        public StaticCoroutine StaticCoroutine;

        [Header("- Settings -")]
        public bool DebugFeatures;

        static string version;
        public static string VersionNumber
        {
            get
            {
                if (string.IsNullOrEmpty(version))
                {
                    version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                }
                return version;
            }
        }

        void Awake()
        {
            var t = DateTime.Now;


            if (SetupInstance())
            {
                InitializeBackend();
                InitializeServices();

                Application.targetFrameRate = 30; //FIX: more?

                //Log.Console.AddStatic("v", typeof(AppServices), "OutputVersion");
                //Log.Console.AddStatic("version", typeof(AppServices), "OutputVersion");
                //
                //Log.Console.AddStatic("quit", typeof(AppServices), "ForceQuit");
                //Log.Console.AddStatic("exit", typeof(AppServices), "ForceQuit");

                var diff = (DateTime.Now - t);
                Debug.Log(string.Format("All Game services loaded in {0} ms ({1} tics)", diff.TotalMilliseconds, diff.Ticks));
            }
        }

        public static void OutputVersion()
        {
            Debug.Log(string.Format("Starting version {0}", VersionNumber));
        }

        public static void ForceQuit()
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif

            Debug.Log(string.Format("Exiting version {0}", VersionNumber));

        }



        void Update()
        {
            //ConsoleManger.Update();
            if(DebugFeatures)
            {
                AppUI.CurrentKeysText.text = Input.inputString;
            }
        }

        bool SetupInstance()
        {
            if (instance == null)
                instance = this;
            else if (instance.gameObject != null)
            {
                Destroy(gameObject);
                Debug.LogError("AppServices: multiple instances detected");
                return false;
            }
            else
                instance = this;

            return true;
        }

        void InitializeBackend()
        {
            DataStorage.Load(Application.persistentDataPath + "/userdata");
        }
        void InitializeServices()
        {
            //ConsoleManger.Initialize();

            AppUI.SetVersion(Application.platform + " " + VersionNumber);
            SceneManager.Initialize();
            cVarManager.Initialize();
            AppInput.Initialize();
        }
    }
}