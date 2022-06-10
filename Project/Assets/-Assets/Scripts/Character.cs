using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float m_MoveSpeed = 3;
    [SerializeField] float m_TurnSpeed = 360;

    Rigidbody m_Rigidbody;
    Animator m_Animator;
    CapsuleCollider m_Capsule;

    float h, v;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        m_Capsule = GetComponent<CapsuleCollider>();
    }

    public void Move(Vector3 move)
    {
        print(move.ToString());

        // 이동.
        Vector3 translation = move * m_MoveSpeed * Time.deltaTime;
        transform.Translate(translation);

        //// 회전.
        //Vector3 euler = new Vector3(0, Mathf.Atan2(move.x, move.z) * m_TurnSpeed * Time.deltaTime, 0);
        //transform.Rotate(euler);
    }
}
