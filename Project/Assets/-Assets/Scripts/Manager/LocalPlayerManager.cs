using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerManager : MonoBehaviour
{
    public PlayerController playerController;
    public Character character;

    [SerializeField] GameObject m_Camera;
    [SerializeField] CinemachineVirtualCamera m_CVC;

    public void Init()
    {
        GameObject go_pc = Managers.Resource.Instantiate("PlayerController");
        DontDestroyOnLoad(go_pc);
        PlayerController pc = go_pc.GetComponent<PlayerController>();

        GameObject go_c = Managers.Resource.Instantiate("Character");
        DontDestroyOnLoad(go_c);
        Character c = go_c.GetComponent<Character>();

        m_Camera = Camera.main.gameObject;
        m_CVC = GameObject.FindObjectOfType<CinemachineVirtualCamera>();

        pc.SetCamera(m_Camera, m_CVC);
        pc.OnPossess(c);
    }
}
