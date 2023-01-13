using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour, IPlayerLeft
{
    public PlayerProfile Profile { get; set; }
    public PlayerChat Chat { get; set; }
    public PlayerController Controller { get; set; }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        Profile = GetComponentInChildren<PlayerProfile>();
        Chat = GetComponentInChildren<PlayerChat>();
        Controller = GetComponentInChildren<PlayerController>();
    }

    public void PlayerLeft(PlayerRef player)
    {
        Debug.Log("PlayerLeft");

        if (player == Object.InputAuthority)
        {
            Runner.Despawn(Object);
        }
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
