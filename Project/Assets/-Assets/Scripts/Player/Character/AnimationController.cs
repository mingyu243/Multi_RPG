using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Automatic Initialize")] // 스크립트에서 자동으로 초기화.
    [SerializeField] Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(float forwardPower)
    {
        _animator.SetFloat("DIRECTION_FORWARD", forwardPower);
    }

    public void Roll()
    {
        _animator.SetTrigger("ROLL");
    }

    public void Jump()
    {
        _animator.SetTrigger("JUMP");
    }

    public void OnGrounded(bool onGrounded)
    {
        _animator.SetBool("ON_GROUNDED", onGrounded);
    }

    public bool IsRolling()
    {
        return _animator.GetBool("IS_ROLLING");
    }
}
