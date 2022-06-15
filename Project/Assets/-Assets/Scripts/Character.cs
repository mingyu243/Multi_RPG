using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float m_MoveSpeed = 3;

    Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }
    public void PlayRoll()
    {
        m_Animator.SetTrigger("ROLL");
    }

    public void Move(Vector3 move)
    {
        if(!CanMove())
        {
            return;
        }

        // 이동 애니메이션.
        m_Animator.SetFloat("DIRECTION_FORWARD", move.magnitude);

        // 이동, 회전.
        Vector3 dir = new Vector3(move.x, 0, move.z);
        if (dir.sqrMagnitude > 0)
        {
            transform.position += dir * m_MoveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.5f);
        }
    }

    private bool CanMove()
    {
        return (m_Animator.GetBool("IS_ROLLING") == false);
    }
}
