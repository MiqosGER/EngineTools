using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneManagerView
{
    public int selectedSceneIndex = 0;

    public void DisplayScenesDropdown(List<string> scenes)
    {
        GUILayout.Label("Available Scenes:", EditorStyles.boldLabel);
        selectedSceneIndex = EditorGUILayout.Popup(selectedSceneIndex, scenes.ToArray());
    }

    public string GetSelectedScene(List<string> scenes)
    {
        if (scenes.Count > 0 && selectedSceneIndex >= 0 && selectedSceneIndex < scenes.Count)
        {
            return scenes[selectedSceneIndex];
        }
        return null;
    }

    public void ShowFeedback(string message)
    {
        EditorGUILayout.HelpBox(message, MessageType.Info);
    }
}
