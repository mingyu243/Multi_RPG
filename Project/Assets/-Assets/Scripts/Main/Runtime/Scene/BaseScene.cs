using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Fusion;
using Fusion.Sockets;
using System;

public abstract class BaseScene : MonoBehaviour
{
    [Header("Automatic Initialize")]
    public Define.Scene SceneType = Define.Scene.Unknown;

}
