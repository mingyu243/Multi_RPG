using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[Overlay(typeof(SceneView), "Test/Direct Join Room Tools")]
public class DirectJoinRoomOverlay : Overlay
{
    VisualElement m_Root;

    const string EDITOR_KEY_ROOM_NAME = "editor_key_room_name";
    const string EDITOR_KEY_NICK_NAME = "eidtor_key_nick_name";

    public override VisualElement CreatePanelContent()
    {
        m_Root = new VisualElement();
        m_Root.Add(CreateRoomNameField());
        m_Root.Add(CreateNickNameField());

        VisualElement btnRoot = new VisualElement();
        btnRoot.style.backgroundColor = Color.white;
        btnRoot.style.marginTop = 5;
        btnRoot.style.flexDirection = FlexDirection.Row;

        btnRoot.Add(CreatePlayButton());

        m_Root.Add(btnRoot);

        return m_Root;
    }

    TextField CreateRoomNameField()
    {
        TextField textField = new TextField("Room Name");
        textField.labelElement.style.minWidth = 100;
        textField.style.minWidth = 100;

        textField.RegisterValueChangedCallback(value =>
        {
            EditorPrefs.SetString(EDITOR_KEY_ROOM_NAME, value.newValue);
        });

        return textField;
    }
    TextField CreateNickNameField()
    {
        TextField textField = new TextField("Nick Name");
        textField.labelElement.style.minWidth = 100;
        textField.style.minWidth = 100;

        textField.RegisterValueChangedCallback(value =>
        {
            EditorPrefs.SetString(EDITOR_KEY_NICK_NAME, value.newValue);
        });

        return textField;
    }

    Button CreatePlayButton()
    {
        Button button = new Button();
        button.text = "Play";
        button.AddToClassList("unity-toolbar-button");

        button.style.flexGrow = 1;
        button.clicked += () => { LoadEditorScene(); };

        return button;
    }

    void LoadEditorScene()
    {
        Scene currentScene = EditorSceneManager.GetActiveScene();
        if(EditorSceneManager.GetActiveScene().isDirty)
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        }

        EditorApplication.EnterPlaymode();

        Managers.Network.SetNickName(EditorPrefs.GetString(EDITOR_KEY_ROOM_NAME, string.Empty));
        Managers.Network.JoinOrCreateRoom(EditorPrefs.GetString(EDITOR_KEY_NICK_NAME, string.Empty), true);
    }
}
