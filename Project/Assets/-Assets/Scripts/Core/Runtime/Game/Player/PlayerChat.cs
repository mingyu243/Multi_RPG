using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChat : NetworkBehaviour
{
    public event Action<string> OnMessageReceived;
    PlayerProfile Profile => Managers.GamePlay.LocalPlayer.Profile;

    public void Chat(string message)
    {
        RPC_Chat(Profile, message);
    }

    public void Connect()
    {
    }

    public void Disconnect()
    {
    }

    /// <summary>
    /// [참고] https://doc.photonengine.com/ko-kr/fusion/current/fusion-100/fusion-106
    /// </summary>
    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    void RPC_Chat(PlayerProfile profile, string message)
    {
        UI_GamePlay uI_GamePlay = Managers.UI.SceneUI as UI_GamePlay;
        if (uI_GamePlay != null)
        {
            uI_GamePlay.AddChatMessage(profile.Name, message);
        }
    }
}
