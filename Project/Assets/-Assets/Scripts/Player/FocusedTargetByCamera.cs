﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 카메라가 바라보는 오브젝트.
/// </summary>
public class FocusedTargetByCamera : MonoBehaviour
{
    [SerializeField] float _rotateSpeed = 5;

    private float yaw;

    public void Follow(Vector3 position)
    {
        transform.position = position;
    }

    /// <summary>
    /// [참고]
    /// https://gamedev.stackexchange.com/questions/104693/how-to-use-input-getaxismouse-x-y-to-rotate-the-camera
    /// </summary>
    public void Rotate(Vector3 rotate)
    {
        yaw += _rotateSpeed * rotate.x;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yaw, 0.0f);

        // 아래와 같이 하면, 짐벌락 걸림.
        //transform.Rotate(rotate * m_RotateSpeed);
    }
}
