using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CameraController CurrentCamera { get { return GameObject.FindObjectOfType<CameraController>(); } }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
