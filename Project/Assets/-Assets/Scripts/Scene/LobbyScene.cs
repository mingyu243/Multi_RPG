using Cinemachine;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    private void Awake()
    {
        SceneType = Define.Scene.Lobby;
    }

    public override void Initialize(NetworkRunner runner)
    {
        print("Initialize");
    }

    public override void Shutdown(NetworkRunner runner)
    {
        print("Shutdown");
    }

    public override bool IsReady(NetworkRunner runner)
    {
        print("IsReady");
        SpawnInitPlayer(runner);

        return true;
    }

    private void SpawnInitPlayer(NetworkRunner runner)
    {
        // 플레이어 컨트롤러 생성.
        NetworkObject pcObject = Managers.Network.Spawn(runner, "PlayerController", inputAuthority: Managers.LocalPlayer.PlayerRef);
        PlayerController pc = pcObject.GetComponent<PlayerController>();

        // 캐릭터 생성.
        NetworkObject cObject = Managers.Network.Spawn(runner, "Character");
        Character c = cObject.GetComponent<Character>();

        pc.OnPossess(c);

        Managers.GamePlay.AddPlayerController(pcObject);
        Managers.LocalPlayer.PlayerController = pc;
    }
}
