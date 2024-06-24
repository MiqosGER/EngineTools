using UnityEditor;
using UnityEngine;

public class SceneManagerWindow : EditorWindow
{
    private SceneManagerController controller;

    [MenuItem("Window/Scene Manager")]
    public static void ShowWindow()
    {
        GetWindow<SceneManagerWindow>("Scene Manager");
    }

    private void OnEnable()
    {
        controller = new SceneManagerController();
    }

    private void OnGUI()
    {
        controller.OnGUI();
    }
}
