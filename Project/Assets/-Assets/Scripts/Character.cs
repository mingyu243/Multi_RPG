using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float m_MoveSpeed = 3;

    public void Move(Vector3 move)
    {
        if(move.sqrMagnitude <= 0)
        {
            return;
        }

        Vector3 dir = new Vector3(move.x, 0, move.z);
        dir.Normalize();

        // 이동.
        transform.position += dir * m_MoveSpeed * Time.deltaTime;

        // 회전.
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.7f);
    }
}
