using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;

namespace Skyrise
{
    public class SceneToolBar : MonoBehaviour
    {
        [MenuItem("Tools/Scenes/Pre scene")]
        public static void LoadPreScene()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene("Assets/App/Scenes/PreScene.unity");
        }
        [MenuItem("Tools/Scenes/Menu")]
        public static void LoadMenu()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene("Assets/App/Scenes/Menu.unity");
        }
        [MenuItem("Tools/Scenes/Game")]
        public static void LoadLevel()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene("Assets/App/Scenes/Game.unity");
        }
        /*
        [MenuItem("Tools/Scenes/Asset tester")]
        public static void LoadAssetTester()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene("Assets/App/Scenes/AssetTester.unity");
        }
        */
    }
}