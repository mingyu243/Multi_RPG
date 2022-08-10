using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Automatic Initialize")] // 스크립트에서 자동으로 초기화.
    [SerializeField] Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void Move(float forwardPower)
    {
        m_Animator.SetFloat("DIRECTION_FORWARD", forwardPower);
    }

    public void Roll()
    {
        m_Animator.SetTrigger("ROLL");
    }

    public void Jump()
    {
        m_Animator.SetTrigger("JUMP");
    }

    public void OnGrounded(bool onGrounded)
    {
        m_Animator.SetBool("ON_GROUNDED", onGrounded);
    }

    public bool IsRolling()
    {
        return m_Animator.GetBool("IS_ROLLING");
    }
}
