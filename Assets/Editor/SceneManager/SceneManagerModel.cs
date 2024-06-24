using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneManagerModel
{
    private List<string> scenes;

    public SceneManagerModel()
    {
        scenes = new List<string>();
        LoadScenes();
    }

    public void LoadScenes()
    {
        scenes.Clear();
        string[] sceneGuids = AssetDatabase.FindAssets("t:Scene", new[] { "Assets" });
        foreach (string guid in sceneGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(path);
            scenes.Add(path);
        }
    }

    public List<string> GetScenes()
    {
        return scenes;
    }
}
