using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager
{
    private Dictionary<PlayerRef, NetworkObject> _spawnedPlayerControllers = new Dictionary<PlayerRef, NetworkObject>();

    public void AddPlayerController(PlayerRef player, NetworkObject no)
    {
        _spawnedPlayerControllers.Add(player, no);
    }
    public bool RemovePlayerController(PlayerRef player, out NetworkObject no)
    {
        if(_spawnedPlayerControllers.TryGetValue(player, out no))
        {
            _spawnedPlayerControllers.Remove(player);
            return true;
        }
        return false;
    }
}
