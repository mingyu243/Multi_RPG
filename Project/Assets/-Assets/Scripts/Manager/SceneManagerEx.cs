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

    string GetSceneName(Define.Scene type)
    {
        string name = System.Enum.GetName(typeof(Define.Scene), type); // C#ÀÇ Reflection.
        return name;
    }

    public void LoadScene(Define.Scene type)
    {
        //Managers.Clear();
        Managers.Network.LoadScene(GetSceneName(type));
    }

    public void Clear()
    {
        //CurrentScene.Clear();
    }
}
