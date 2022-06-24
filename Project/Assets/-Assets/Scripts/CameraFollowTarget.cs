using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField] float m_RotateSpeed = 5;

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
        yaw += m_RotateSpeed * rotate.x;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yaw, 0.0f);

        // 아래와 같이 하면, 짐벌락 걸림.
        //transform.Rotate(rotate * m_RotateSpeed);
    }
}
