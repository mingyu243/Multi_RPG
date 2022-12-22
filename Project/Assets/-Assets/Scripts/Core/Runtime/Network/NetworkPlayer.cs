using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    public void PlayerLeft(PlayerRef player)
    {
        Debug.Log("PlayerLeft");

        if (player == Object.InputAuthority)
        {
            Runner.Despawn(Object);
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public override void Spawned()
    {
        base.Spawned();

        if (Object.HasInputAuthority)
        {
            Debug.Log("Spawned me");
        }
        else
        {
            Debug.Log("Spawned other player");
        }
    }
}
