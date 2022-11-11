using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Vector3 Forward { get { return _cineBrain.transform.forward; } }
    public Vector3 Right { get { return _cineBrain.transform.right; } }

    CinemachineBrain _cineBrain;
    public CinemachineBrain CineBrain
    {
        get
        {
            if (_cineBrain == null)
            {
                //_cineBrain = GameObject.FindObjectOfType<CinemachineBrain>();
                _cineBrain = CinemachineCore.Instance.GetActiveBrain(0);
            }
            return _cineBrain;
        }
    }

    [SerializeField] CameraController _cameraController;
    public CameraController CurrentCamera
    {
        get
        {
            if (_cameraController == null)
            {
                _cameraController = CineBrain.ActiveVirtualCamera?.VirtualCameraGameObject.GetComponent<CameraController>();
            }
            return _cameraController;
        }
    }

    public void SetFollowTarget(Transform transform)
    {
        if(CurrentCamera != null)
        {
            CurrentCamera.Follow(transform);
        }
        else
        {
            // 시네머신 ActiveVirtualCamera 변수는 한번의 LateUpdate 이후로 값이 설정된다.
            // 그래서 시작하자마자 Start에서 접근하면 null이 뜬다.
            // 해결하기 위해서 한 프레임 기다려줌.
            StartCoroutine(Delay());
        }

        IEnumerator Delay()
        {
            yield return null;
            CurrentCamera.Follow(transform);
        }
    }
}
