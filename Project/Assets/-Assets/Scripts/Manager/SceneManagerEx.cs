using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }

    public int GetBuildIndex(Define.Scene type)
    {
        return (int)type;
    }

    public void LoadScene(Define.Scene type)
    {
        //Managers.Clear();
        Managers.Network.SetActiveScene(type);
    }

    public void Clear()
    {
        //CurrentScene.Clear();
    }
}
