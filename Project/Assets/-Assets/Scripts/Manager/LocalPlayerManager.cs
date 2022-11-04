using Cinemachine;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerManager
{
    PlayerRef _playerRef;
    PlayerController _playerController;

    public PlayerRef PlayerRef
    {
        get { return _playerRef; }
        set { _playerRef = value; }
    }
    public PlayerController PlayerController 
    { 
        get { return _playerController; } 
        set { _playerController = value; } 
    }
}
