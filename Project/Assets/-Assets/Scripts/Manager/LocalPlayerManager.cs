using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerManager
{
    public PlayerController playerController;
    public Character character;

    [SerializeField] GameObject m_Camera;
    [SerializeField] CinemachineVirtualCamera m_CVC;

    public void Init()
    {
    }

    public void CreatePlayerController()
    {
        GameObject pc = Managers.Resource.Instantiate("PlayerController");
        Object.DontDestroyOnLoad(pc);

        playerController = pc.GetComponent<PlayerController>();
    }

    public void CreateCharacter()
    {
        character = Managers.Network.Instantiate("Character").GetComponent<Character>();
    }

    public void SetPossess()
    {
        m_Camera = Camera.main.gameObject;
        m_CVC = GameObject.FindObjectOfType<CinemachineVirtualCamera>();

        playerController.SetCamera(m_Camera, m_CVC);
        playerController.OnPossess(character);
    }
}
