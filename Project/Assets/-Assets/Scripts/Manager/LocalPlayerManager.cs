using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerManager
{
    PlayerController _playerController;

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
}
