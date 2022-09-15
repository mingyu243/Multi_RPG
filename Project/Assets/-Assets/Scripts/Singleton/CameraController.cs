using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _cvc;

    private void Awake()
    {
        _cvc = GetComponent<CinemachineVirtualCamera>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
