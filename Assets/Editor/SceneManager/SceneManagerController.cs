using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SceneManagerController
{
    private SceneManagerModel model;
    private SceneManagerView view;

    public SceneManagerController()
    {
        model = new SceneManagerModel();
        view = new SceneManagerView();
    }

    public void OnGUI()
    {
        view.DisplayScenesDropdown(model.GetScenes());

        if (GUILayout.Button("Refresh Scenes"))
        {
            OnLoadButtonClicked();
        }

        if (GUILayout.Button("Load Selected Scene"))
        {
            OnLoadSelectedSceneButtonClicked();
        }

        if (GUILayout.Button("Save Current Scene"))
        {
            OnSaveButtonClicked();
        }
    }

    private void OnLoadButtonClicked()
    {
        model.LoadScenes();
        UpdateView();
    }

    private void OnLoadSelectedSceneButtonClicked()
    {
        string selectedScene = view.GetSelectedScene(model.GetScenes());
        if (!string.IsNullOrEmpty(selectedScene))
        {
            LoadSelectedScene(selectedScene);
            view.ShowFeedback("Scene loaded successfully!");
        }
        else
        {
            view.ShowFeedback("No scene selected.");
        }
    }

    private void OnSaveButtonClicked()
    {
        SaveCurrentScene();
    }

    private void SaveCurrentScene()
    {
        string currentScenePath = EditorSceneManager.GetActiveScene().path;
        if (!string.IsNullOrEmpty(currentScenePath))
        {
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene(), currentScenePath);
            view.ShowFeedback("Scene saved successfully!");
        }
        else
        {
            view.ShowFeedback("No active scene to save.");
        }
    }

    private void LoadSelectedScene(string scenePath)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(scenePath);
        }
    }

    private void UpdateView()
    {
        view.DisplayScenesDropdown(model.GetScenes());
    }
}
