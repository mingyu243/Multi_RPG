using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Automatic Initialize")] // 스크립트에서 자동으로 초기화.
    [SerializeField] Rigidbody m_Rigidbody;
    [SerializeField] AnimationController m_AnimationController;

    [Header("Manual Initialize")] // 인스펙터에서 수동으로 초기화.
    [SerializeField] LayerMask m_CheckOnGroundedLayer;

    [Header("Inputs")] // 입력받은 값.
    [SerializeField] Vector3 m_InputMove;
    [SerializeField] Vector3 m_MoveXZ;
    [SerializeField] float m_ForwardPower;

    [Header("Stats")] // 능력. 
    [SerializeField] float m_MoveSpeed = 7;
    [SerializeField] float m_JumpPower = 12;
    [SerializeField] float m_RollPower = 12;
    [SerializeField] float m_CheckOnGroundedLength = 0.3f;

    [Header("States")] // 상태.
    [SerializeField] bool m_IsRolling;
    [SerializeField] bool m_OnGrounded;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        m_AnimationController = GetComponent<AnimationController>();
    }

    public void PlayRoll()
    {
        if(!CanRoll())
        {
            return;
        }

        DirectRotate();
        m_Rigidbody.AddForce(transform.forward * m_RollPower + Vector3.up * -Physics.gravity.y, ForceMode.Impulse);
        m_AnimationController.Roll();
    }
    public void PlayJump()
    {
        if (!CanJump())
        {
            return;
        }
        
        m_Rigidbody.AddForce(Vector3.up * m_JumpPower, ForceMode.Impulse);
        m_AnimationController.Jump();
    }

    private void Update()
    {
        m_OnGrounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, m_CheckOnGroundedLength, m_CheckOnGroundedLayer);
        m_AnimationController.OnGrounded(m_OnGrounded);

        m_IsRolling = m_AnimationController.IsRolling();
    }

    public void Move(Vector3 inputMove)
    {
        m_InputMove = inputMove;

        // 앞으로 가는 속력 구하기.
        m_ForwardPower = Mathf.Clamp(m_InputMove.magnitude, 0, 1); // 대각선으로 갈 때, 빨라지는 것을 방지.
        m_AnimationController.Move(m_ForwardPower);

        // 이동하기.
        if ((m_ForwardPower > 0) && CanMove())
        {
            m_MoveXZ = new Vector3(m_InputMove.x, 0, m_InputMove.z); // Y축을 제외한 방향 구하기.
            m_MoveXZ.Normalize();

            //transform.position += (m_MoveXZ * m_MoveSpeed) * m_ForwardPower * Time.deltaTime;
            m_Rigidbody.MovePosition(transform.position + (m_MoveXZ * m_MoveSpeed) * m_ForwardPower * Time.deltaTime);
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
        return (m_IsRolling == false);
    }

    private bool CanRoll()
    {
        return (m_IsRolling == false);
    }

    private bool CanJump()
    {
        return (m_OnGrounded == true);
    }
}
