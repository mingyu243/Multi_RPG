using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
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
    private Character m_Character;
    private Transform m_Cam;

    private Vector3 m_PlayerMovementInput;
    private Vector3 m_PlayerMouseInput;

    private void Start()
    {
        m_Cam = Camera.main.transform;
        m_Character = GetComponent<Character>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        m_PlayerMovementInput = (v * m_Cam.forward) + (h * m_Cam.right);
        m_PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    private void FixedUpdate()
    {
        m_Character.Move(m_PlayerMovementInput);
    }
}
