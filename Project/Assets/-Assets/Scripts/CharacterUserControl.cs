using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
public class CharacterUserControl : MonoBehaviour
{
    public Character character;
    public FollowTarget followTarget;

    private Transform m_Cam;

    private Vector3 m_PlayerMovementInput;
    private Vector3 m_PlayerMouseInput;



    private void Start()
    {
        m_Cam = Camera.main.transform;
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        m_PlayerMovementInput = (v * m_Cam.forward) + (h * m_Cam.right);
        m_PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.PlayRoll();
        }
    }

    private void FixedUpdate()
    {
        // 캐릭터 이동.
        character.Move(m_PlayerMovementInput);

        // 카메라 타겟 위치를 캐릭터 위치로 옮기기.
        followTarget.Follow(character.transform.position);
        followTarget.Rotate(m_PlayerMouseInput);
    }
}
