using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    [Header("Automatic Initialize")]
    public Define.Scene SceneType = Define.Scene.Unknown;

    [Header("Manual Initialize")] // 인스펙터에서 수동으로 초기화.
    public CameraController 

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        // UI는 따로 씬 분리할 거라서.
        //Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        //if(obj == null)
        //{
        //    Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
        //}
    }

    public abstract void Clear();
}
