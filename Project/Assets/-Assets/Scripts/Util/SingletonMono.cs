using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    static T s_instance;

    static protected T Instance { get { Init(); return s_instance; } }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.FindObjectOfType<T>().gameObject;
            if (go == null)
            {
                string name = typeof(T).Name;
                go = new GameObject(name);
                
                s_instance = go.AddComponent<T>();
            }
        }
    }
}
