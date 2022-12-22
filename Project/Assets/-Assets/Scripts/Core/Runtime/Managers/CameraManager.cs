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
            // �ó׸ӽ� ActiveVirtualCamera ������ �ѹ��� LateUpdate ���ķ� ���� �����ȴ�.
            // �׷��� �������ڸ��� Start���� �����ϸ� null�� ���.
            // �ذ��ϱ� ���ؼ� �� ������ ��ٷ���.
            StartCoroutine(Delay());
        }

        IEnumerator Delay()
        {
            yield return null;
            CurrentCamera.Follow(transform);
        }
    }
}
