using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEditor.SceneManagement;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[Overlay(typeof(SceneView), "Test/Move Scene")]
public class MoveSceneOverlay : Overlay
{
    string SelectScenePath1
    {
        get { return EditorPrefs.GetString("test_select_scene_path1", string.Empty); }
        set { EditorPrefs.SetString("test_select_scene_path1", value); }
    }
    string SelectScenePath2
    {
        get { return EditorPrefs.GetString("test_select_scene_path2", string.Empty); }
        set { EditorPrefs.SetString("test_select_scene_path2", value); }
    }

    public override VisualElement CreatePanelContent()
    {
        VisualElement root = new VisualElement();
        root.Add(CreateField_SelectScene1());
        root.Add(CreateButton_OpenSelectScene1());
        root.Add(Create_Padding());
        root.Add(CreateField_SelectScene2());
        root.Add(CreateButton_OpenSelectScene2());
        return root;

        VisualElement Create_Padding()
        {
            VisualElement v = new VisualElement();
            v.style.paddingBottom = 10;
            return v;
        }
        ObjectField CreateField_SelectScene1()
        {
            ObjectField o = new ObjectField();
            o.objectType = typeof(SceneAsset);
            o.value = AssetDatabase.LoadAssetAtPath<SceneAsset>(SelectScenePath1);
            o.RegisterValueChangedCallback(e =>
            {
                SelectScenePath1 = AssetDatabase.GetAssetPath(e.newValue as SceneAsset);
            });
            o.label = "Select Scene";
            return o;
        }
        Button CreateButton_OpenSelectScene1()
        {
            Button b = new Button();
            b.style.flexGrow = 1;
            b.text = "Open";
            b.AddToClassList("unity-toolbar-button");
            b.clicked += () =>
            {
                if (AssetDatabase.LoadAssetAtPath<SceneAsset>(SelectScenePath1) == null)
                {
                    return;
                }

                OpenScene(SelectScenePath1);
            };
            return b;
        }

        ObjectField CreateField_SelectScene2()
        {
            ObjectField o = new ObjectField();
            o.objectType = typeof(SceneAsset);
            o.value = AssetDatabase.LoadAssetAtPath<SceneAsset>(SelectScenePath2);
            o.RegisterValueChangedCallback(e =>
            {
                SelectScenePath2 = AssetDatabase.GetAssetPath(e.newValue as SceneAsset);
            });
            o.label = "Select Scene";
            return o;
        }
        Button CreateButton_OpenSelectScene2()
        {
            Button b = new Button();
            b.style.flexGrow = 1;
            b.text = "Open";
            b.AddToClassList("unity-toolbar-button");
            b.clicked += () =>
            {
                if (AssetDatabase.LoadAssetAtPath<SceneAsset>(SelectScenePath2) == null)
                {
                    return;
                }

                OpenScene(SelectScenePath2);
            };
            return b;
        }
    }

    void OpenScene(string scenePath)
    {
        if (EditorSceneManager.GetActiveScene().isDirty)
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        }

        EditorSceneManager.OpenScene(scenePath);
    }
}