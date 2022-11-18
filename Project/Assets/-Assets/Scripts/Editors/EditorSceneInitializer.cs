#if UNITY_EDITOR

using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EditorSceneInitializer : SingletonMono<EditorSceneInitializer>
{
    public string ScenePath;
    public string SessionName;
    public string Nickname;

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

    void Start()
    {
        Debug.Log($"NickName : {Nickname}");

        Managers.LocalPlayer.InputNickname = Nickname;
        Managers.Network.StartGame(SessionName);
    }
}

#endif