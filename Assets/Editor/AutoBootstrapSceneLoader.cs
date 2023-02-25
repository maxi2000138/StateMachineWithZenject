using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    [InitializeOnLoad]
    public static class LoadBootstrapScene
    {
        private static string PREVIOUS_SCENE_PATH = "PREVIOUS_SCENE";
        static LoadBootstrapScene()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
            {
                string currentPath = SceneManager.GetActiveScene().path;
                EditorPrefs.SetString(PREVIOUS_SCENE_PATH,currentPath);
                
                if (SceneManager.GetActiveScene().buildIndex == 0)
                    return;

                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    string path = EditorBuildSettings.scenes[0].path;
                    try
                    {
                        EditorSceneManager.OpenScene(path);
                    }
                    catch
                    {
                        Debug.LogError($"Cant load scene {path}...");
                        EditorApplication.isPlaying = false;
                        EditorApplication.ExitPlaymode();
                    }
                }
                else
                {
                    EditorApplication.isPlaying = false;
                }

            }

            if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
            {
                var path = EditorPrefs.GetString(PREVIOUS_SCENE_PATH);
                if(SceneManager.GetActiveScene().path == path)
                    return;
                
                try
                {
                    EditorSceneManager.OpenScene(path);
                }
                catch
                {
                    Debug.LogError($"Cant load scene {path}...");
                    Application.Quit();
                    EditorApplication.isPlaying = false;
                }
            }
        }
    }
}
