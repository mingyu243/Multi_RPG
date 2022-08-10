using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// 
/// [참고]
/// 
/// 시네머신 관련.
/// + https://www.youtube.com/watch?v=537B1kJp9YQ
/// 
/// 플레이어 이동 관련.
/// + https://www.youtube.com/watch?v=b1uoLBp2I1w
/// + Photon 데모 스크립트. (ThirdPersonUserControl, ThirdPersonCharacter)
/// 
/// </summary>
public class PlayerController : MonoBehaviourPun
{
    [Header("Automatic Initialize")] // 스크립트에서 자동으로 초기화.
    [SerializeField] Transform m_Cam;
    [SerializeField] Character m_Character;

    [Header("Manual Initialize")] // 인스펙터에서 수동으로 초기화.
    [SerializeField] CameraFollowTarget m_CameraFollowTarget;

    [Header("Inputs")]
    [SerializeField] float m_Horizontal; // 수평. (좌우)
    [SerializeField] float m_Vertical; // 수직. (위아래)
    [SerializeField] float m_MouseX; // 마우스 좌우.

    [SerializeField] Vector3 m_PlayerMovementInput;
    [SerializeField] Vector3 m_PlayerMouseInput;


    private void Start()
    {
        m_Cam = Camera.main.transform;

        if (m_Character != null)
        {
            m_Character = PhotonNetwork.Instantiate("MinePlayer", Vector3.zero, Quaternion.identity).GetComponent<Character>();
        }
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        m_Horizontal = Input.GetAxis("Horizontal");
        m_Vertical = Input.GetAxis("Vertical");
        m_MouseX = Input.GetAxis("Mouse X");

        m_PlayerMovementInput = (m_Vertical * m_Cam.forward) + (m_Horizontal * m_Cam.right);
        m_PlayerMouseInput = new Vector2(m_MouseX, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_Character.PlayRoll();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Character.PlayJump();
        }
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        // 캐릭터 이동.
        m_Character.Move(m_PlayerMovementInput);

        // 카메라 타겟 위치를 캐릭터 위치로 옮기기.
        m_CameraFollowTarget.Follow(m_Character.transform.position);
        m_CameraFollowTarget.Rotate(m_PlayerMouseInput);
    }
}
