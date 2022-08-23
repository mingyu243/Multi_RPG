using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditorSceneInitializer : SingletonMono<EditorSceneInitializer>
{
    public string ScenePath;
    public string RoomName;
    public string NickName;
    public bool IsOffline;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        RecoveryScene();
    }

    /// <summary>
    /// 에디터에서 플레이모드가 꺼질 경우, 시작했던 씬으로 돌아옴.
    /// </summary>
    void RecoveryScene()
    {
        EditorApplication.playModeStateChanged += Changed;

        void Changed(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredEditMode)
            {
                EditorApplication.playModeStateChanged -= Changed;
                EditorSceneManager.OpenScene(ScenePath);
            }
        }
    }

    async UniTaskVoid Start()
    {
        Debug.Log($"NickName : {NickName}");
        Debug.Log($"IsOffline : {IsOffline}");

        SceneManager.sceneLoaded += OnSceneLoaded;

        Managers.Network.SetNickName(NickName);
        await Managers.Network.JoinOrCreateRoomAsync(RoomName);
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        Managers.LocalPlayer.CreatePlayerController();
        Managers.LocalPlayer.CreateCharacter();
        Managers.LocalPlayer.SetPossess();
    }
}
