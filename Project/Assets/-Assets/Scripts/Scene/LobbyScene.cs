using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Lobby;

        if (Managers.Network.IsConnect)
        {
            Managers.LocalPlayer.CreatePlayerController();
            Managers.LocalPlayer.CreateCharacter();
            Managers.LocalPlayer.SetPossess();
        }
    }

    public override void Clear()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
