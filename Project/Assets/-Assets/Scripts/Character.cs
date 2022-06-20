using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float m_MoveSpeed = 3;

    Animator m_Animator;

    Vector3 m_InputMove;
    Vector3 m_MoveXZ;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }
    public void PlayRoll()
    {
        if(!CanRoll())
        {
            return;
        }

        DirectRotate();
        m_Animator.SetTrigger("ROLL");
    }

    public void Move(Vector3 inputMove)
    {
        m_InputMove = inputMove;

        m_MoveXZ = new Vector3(m_InputMove.x, 0, m_InputMove.z);

        if (!CanMove())
        {
            return;
        }

        // 이동 애니메이션.
        m_Animator.SetFloat("DIRECTION_FORWARD", m_InputMove.magnitude);

        if (m_MoveXZ.sqrMagnitude > 0)
        {
            m_MoveXZ.Normalize();
            transform.position += m_MoveXZ * m_MoveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(m_MoveXZ), 0.3f);
        }
    }
    private void DirectRotate()
    {
        if (m_MoveXZ.sqrMagnitude > 0)
        {
            m_MoveXZ.Normalize();
            transform.rotation = Quaternion.LookRotation(m_MoveXZ);
        }
    }

    private bool CanMove()
    {
        return (m_Animator.GetBool("IS_ROLLING") == false);
    }

    private bool CanRoll()
    {
        return (m_Animator.GetBool("IS_ROLLING") == false);
    }
}
