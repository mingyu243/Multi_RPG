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
    public Character Character
    {
        get { return _playerController.Character; }
    }

    public void Init()
    {
    }

    public PlayerController CreatePlayerController()
    {
        return Managers.Network.Instantiate("PlayerController").GetComponent<PlayerController>();
    }

    public Character CreateCharacter()
    {
        return Managers.Network.Instantiate("Character").GetComponent<Character>();
    }

    public void OnPossess(Character character)
    {
        _playerController.OnPossess(character);
    }

    public void SetCamera()
    {
        _camera = Camera.main.gameObject;
        _cvc = GameObject.FindObjectOfType<CinemachineVirtualCamera>();

        _playerController.SetCamera(_camera, _cvc);
    }
}
