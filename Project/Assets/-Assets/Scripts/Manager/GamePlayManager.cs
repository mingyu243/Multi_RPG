using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager
{
    Dictionary<int, PlayerController> _playerControllers = new Dictionary<int, PlayerController>();

    public Dictionary<int, PlayerController> PlayerControllers { get { return _playerControllers; } }

    public void AddPlayerController(PlayerController pc)
    {
        _playerControllers.Add(pc.photonView.ViewID, pc);
    }
}
