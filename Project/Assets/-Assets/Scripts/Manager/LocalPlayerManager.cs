using Cinemachine;
using Fusion;
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
}
