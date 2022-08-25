using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerManager
{
    PlayerController _playerController;

    GameObject _camera;
    CinemachineVirtualCamera _cvc;

    public PlayerController PlayerController 
    { 
        get { return _playerController; } 
        set { _playerController = value; } 
    }

    public void Init()
    {
    }

    public PlayerController CreatePlayerController()
    {
        return Managers.Network.Instantiate("PlayerController").GetComponent<PlayerController>();
    }

    public void CreateCharacter()
    {
        character = Managers.Network.Instantiate("Character").GetComponent<Character>();
    }

    public void OnPossess(Character character)
    {
        playerController.OnPossess(character);
    }

    public void SetCamera()
    {
        m_Camera = Camera.main.gameObject;
        m_CVC = GameObject.FindObjectOfType<CinemachineVirtualCamera>();

        playerController.SetCamera(m_Camera, m_CVC);
    }
}
