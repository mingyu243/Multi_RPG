using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float m_MoveSpeed = 7;
    [SerializeField] float m_JumpPower = 5;

    [Header("장비 소켓")]
    [SerializeField] SkinnedMeshRenderer socket_belt;

    Animator m_Animator;
    Rigidbody m_Rigidbody;

    Vector3 m_InputMove;
    Vector3 m_MoveXZ;

    // 상태.
    private bool IsRolling { get { return m_Animator.GetBool("IS_ROLLING"); }}
    private bool IsGrounded;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
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
    public void PlayJump()
    {
        if (!CanJump())
        {
            return;
        }
        
        m_Rigidbody.AddForce(Vector3.up * m_JumpPower, ForceMode.Impulse);
        m_Animator.SetTrigger("JUMP");
    }

    private void Update()
    {
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.3f);
        m_Animator.SetBool("IS_GROUNDED", IsGrounded);
    }

    public void Move(Vector3 inputMove)
    {
        m_InputMove = inputMove;

        m_MoveXZ = new Vector3(m_InputMove.x, 0, m_InputMove.z);
        m_MoveXZ.Normalize();

        if (!CanMove())
        {
            return;
        }

        // 이동 애니메이션.
        float forwardPower = m_MoveXZ.magnitude;
        m_Animator.SetFloat("DIRECTION_FORWARD", forwardPower);

        if (forwardPower > 0)
        {
            transform.position += (m_MoveXZ * m_MoveSpeed) * forwardPower * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(m_MoveXZ), 0.3f);
        }
    }
    private void DirectRotate()
    {
        if (m_MoveXZ.sqrMagnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(m_MoveXZ);
        }
    }

    private bool CanMove()
    {
        return (IsRolling == false);
    }

    private bool CanRoll()
    {
        return (IsRolling == false);
    }

    private bool CanJump()
    {
        return (IsGrounded == true);
    }
}
