using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager
{
    private Dictionary<PlayerRef, NetworkObject> _spawnedPlayerControllers = new Dictionary<PlayerRef, NetworkObject>();

    public void AddPlayerController(NetworkObject no)
    {
        _spawnedPlayerControllers.Add(Managers.LocalPlayer.PlayerRef, no);
    }
}
