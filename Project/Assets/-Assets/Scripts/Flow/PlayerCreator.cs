using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour
{
    [SerializeField] GameObject m_Camera;
    [SerializeField] CinemachineVirtualCamera m_CVC;

    void Start()
    {
        PlayerController pc = PhotonNetwork.Instantiate("PlayerController", Vector3.zero, Quaternion.identity).GetComponent<PlayerController>();
        Character c = PhotonNetwork.Instantiate("Character", Vector3.zero, Quaternion.identity).GetComponent<Character>();

        pc.SetCamera(m_Camera, m_CVC);
        pc.OnPossess(c);
    }
}
