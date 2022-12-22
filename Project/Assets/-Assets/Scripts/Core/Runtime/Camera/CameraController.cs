using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    CinemachineVirtualCamera _cvc;

    private void Awake()
    {
        _cvc = GetComponent<CinemachineVirtualCamera>();
    }

    public void Follow(Transform transform)
    {
        _cvc.Follow = transform;
    }
}
