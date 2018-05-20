using UnityEngine;
using System.Collections;
using Zenject;

namespace PROJECT_HUSKY
{
    public class SceneManager : IInitializable
    {
        public static bool DebugMode { get; set; } = true; 

        readonly OnChangeScene _onChangeSceneSignal;

        public Scene CurrentScene { get; private set; }

        public SceneManager(OnChangeScene onChangeSceneSignal)
        {
            _onChangeSceneSignal = onChangeSceneSignal;
        }
        
        public void Initialize()
        {
            Debug.Log("Initializing SceneManager");
            CurrentScene = 0;
        }

        public void ChangeScene(Scene scene)
        {
            if(DebugMode)
            {
                Debug.Log($"Chaning scene| {CurrentScene} >> {scene}");
            }

            CurrentScene = scene;
            UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);

            _onChangeSceneSignal.Fire(scene);
        }
    }
}