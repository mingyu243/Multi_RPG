using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorSceneInitializer : SingletonMono<EditorSceneInitializer>
{
    public string SceneName;
    public string RoomName;
    public string NickName;
    public bool IsOffline;

    async UniTask Start()
    {
        Debug.Log($"NickName : {NickName}");
        Debug.Log($"IsOffline : {IsOffline}");

        await 

    }
}
