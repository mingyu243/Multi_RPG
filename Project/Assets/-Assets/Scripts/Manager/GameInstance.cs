using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [참고]
/// https://velog.io/@starkshn/Data-Manager
/// </summary>
public class GameInstance : MonoBehaviour
{
    static GameInstance s_instance;

    static GameInstance Instance { get { Init(); return s_instance; } }

    DataManager _data = new DataManager();

    public static DataManager Data { get { return Instance._data; } }


    void Start()
    {
        Init();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@GameInstance");
            if(go == null)
            {
                go = new GameObject("@GameInstance");
                go.AddComponent<GameInstance>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<GameInstance>();

            s_instance._data.Init();

        }
    }
}
