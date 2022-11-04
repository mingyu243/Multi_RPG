using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Fusion;

public abstract class BaseScene : NetworkBehaviour, INetworkSceneManager
{
    [Header("Automatic Initialize")]
    public Define.Scene SceneType = Define.Scene.Unknown;


    public abstract void Initialize(NetworkRunner runner);

    public abstract void Shutdown(NetworkRunner runner);

    public abstract bool IsReady(NetworkRunner runner);
}
