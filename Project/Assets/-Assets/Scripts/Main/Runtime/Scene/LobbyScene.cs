using Cinemachine;
using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene, INetworkRunnerCallbacks
{
    private void Awake()
    {
        SceneType = Define.Scene.Lobby;
    }

    private void Start()
    {
        print("LobbyScene Start : Spawned Unit & Possess");

        // 플레이어 컨트롤러 생성.
        NetworkObject pcObject = Managers.Network.Spawn("Player", inputAuthority: Managers.Network.Runner.LocalPlayer);
        Player player = pcObject.gameObject.GetComponent<Player>();

        // 캐릭터 생성.
        NetworkObject cObject = Managers.Network.Spawn("Character", inputAuthority: Managers.Network.Runner.LocalPlayer);
        Unit c = cObject.gameObject.GetComponent<Unit>();

        player.Controller.Possess(c);

        // 로그인할 때 저장해두었던 닉네임 세팅.
        player.Profile.Name = Managers.GamePlay.StartNickName;
        Managers.GamePlay.LocalPlayer = player;
    }

    public void OnConnectedToServer(NetworkRunner runner) { }

    public void OnSceneLoadDone(NetworkRunner runner)
    {

    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
    public void OnDisconnectedFromServer(NetworkRunner runner) { }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
    public void OnInput(NetworkRunner runner, NetworkInput input) { }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) { }

    public void OnSceneLoadStart(NetworkRunner runner) { }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
}
