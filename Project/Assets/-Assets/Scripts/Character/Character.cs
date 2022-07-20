using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Automatic Initialize")] // 스크립트에서 자동으로 초기화.
    [SerializeField] Animator m_Animator;
    [SerializeField] Rigidbody m_Rigidbody;

    [Header("Manual Initialize")] // 인스펙터에서 수동으로 초기화.
    [SerializeField] SkinnedMeshRenderer m_SocketBelt;

    [Header("Inputs")] // 입력받은 값.
    [SerializeField] Vector3 m_InputMove;
    [SerializeField] Vector3 m_MoveXZ;
    [SerializeField] float m_ForwardPower;

    [Header("Stats")] // 능력. 
    [SerializeField] float m_MoveSpeed = 7;
    [SerializeField] float m_JumpPower = 5;

    //[Header("States")] // 상태.
    [SerializeField] bool IsRolling { get { return m_Animator.GetBool("IS_ROLLING"); }}
    [SerializeField] bool IsGrounded;

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

        // 앞으로 가는 속력 구하기.
        m_ForwardPower = Mathf.Clamp(m_InputMove.magnitude, 0, 1); // 대각선으로 갈 때, 빨라지는 것을 방지.
        m_Animator.SetFloat("DIRECTION_FORWARD", m_ForwardPower);

        // 이동하기.
        if ((m_ForwardPower > 0) && CanMove())
        {
            m_MoveXZ = new Vector3(m_InputMove.x, 0, m_InputMove.z); // Y축을 제외한 방향 구하기.
            m_MoveXZ.Normalize();

            transform.position += (m_MoveXZ * m_MoveSpeed) * m_ForwardPower * Time.deltaTime;
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
