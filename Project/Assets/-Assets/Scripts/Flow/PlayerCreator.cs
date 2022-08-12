using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject m_Camera;
    [SerializeField] CinemachineVirtualCamera m_CVC;

    void Start()
    {
        PlayerController pc = Managers.Resource.Load<GameObject>("PlayerController").GetComponent<PlayerController>();
        Character c = Managers.Resource.Load<GameObject>("Character").GetComponent<Character>();

        pc.SetCamera(m_Camera, m_CVC);
        pc.OnPossess(c);
    }

    public override void OnJoinedRoom()
    {
        print("OnJoinedRoom");

        PhotonNetwork.LoadLevel("BasicScene");
    }
}
