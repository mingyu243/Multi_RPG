using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorSceneInitializer : SingletonMono<EditorSceneInitializer>
{
    public string ScenePath;
    public string RoomName;
    public string NickName;
    public bool IsOffline;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    async UniTaskVoid Start()
    {
        Debug.Log($"NickName : {NickName}");
        Debug.Log($"IsOffline : {IsOffline}");

        Managers.Network.SetNickName(NickName);
        await Managers.Network.JoinOrCreateRoomAsync(RoomName);
    }
}
