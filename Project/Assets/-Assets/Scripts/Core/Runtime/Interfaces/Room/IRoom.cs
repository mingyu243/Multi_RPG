using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRoom
{
    event Action OnLeftMaster;

    event Action<Player> OnPlayerEntered;
    event Action<Player> OnPlayerLeft;

    Dictionary<PlayerRef, Player> Players { get; }

    //Dictionary<PlayerRef, NetworkObject> _spawnedPlayerControllers = new Dictionary<PlayerRef, NetworkObject>();
}
