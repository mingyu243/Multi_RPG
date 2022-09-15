using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    CinemachineBrain _cineBrain;

    public CameraController CurrentCamera 
    { 
        get 
        { 
            return _cineBrain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CameraController>(); 
        } 
    }

    public void Init()
    {
        _cineBrain = GameObject.FindObjectOfType<CinemachineBrain>();
    }
}
