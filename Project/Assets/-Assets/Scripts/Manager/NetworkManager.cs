using Cysharp.Threading.Tasks;
using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManager : NetworkBehaviour, INetworkRunnerCallbacks
{
    //PlayerRef _playerRef;

    //public PlayerRef PlayerRef
    //{
    //    get { return _playerRef; }
    //    set { _playerRef = value; }
    //}

    public void SetNickName(string nickName)
    {
        //PhotonNetwork.LocalPlayer.NickName = nickName;
    }
    public void StartGame(string sessionName)
    {
        StartGameAsync(sessionName).Forget();
    }
    public async UniTask StartGameAsync(string sessionName)
    {
        await this.gameObject.AddComponent<NetworkRunner>().StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = sessionName,
            Scene = Managers.Scene.GetBuildIndex(Define.Scene.Lobby)
        });
    }
    
    public void SetActiveScene(Define.Scene type)
    {
        Runner.SetActiveScene(Managers.Scene.GetBuildIndex(type));
    }

    public NetworkObject Spawn(string prefabPath, Vector3? position = null, Quaternion? rotation = null, PlayerRef? inputAuthority = null)
    {
        return Spawn(Managers.Resource.Load<GameObject>($"Prefabs/{prefabPath}"), position, rotation, inputAuthority);
    }
    public NetworkObject Spawn(GameObject prefab, Vector3? position = null, Quaternion? rotation = null, PlayerRef? inputAuthority = null)
    {
        return Runner.Spawn(prefab, position, rotation, inputAuthority);
    }
    public NetworkPlayer Spawn(NetworkPlayer prefab, Vector3? position = null, Quaternion? rotation = null, PlayerRef? inputAuthority = null)
    {
        return Runner.Spawn(prefab, position, rotation, inputAuthority);
    }

    #region Callbacks
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
    }
    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        //Managers.Input.OnUpdate();
    }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
    }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
    }
    public void OnConnectedToServer(NetworkRunner runner)
    {
    }
    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
    }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
    }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
    }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
    }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
    }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
    }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
    }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
    }
    public void OnSceneLoadDone(NetworkRunner runner)
    {
    }
    public void OnSceneLoadStart(NetworkRunner runner)
    {
    }
    #endregion

    //public PhotonView GetPhotonView(int viewID)
    //{
    //    return PhotonNetwork.GetPhotonView(viewID);
    //}

    //#region 포톤 콜백 함수

    //public override void OnConnectedToMaster()
    //{
    //    _isConnectedToMaster = true;
    //    print("OnConnectedToMaster");
    //}

    //public override void OnCreatedRoom()
    //{
    //    print("OnCreateRoom");
    //}

    //public override void OnJoinedRoom()
    //{
    //    print("OnJoinedRoom");

    //    Managers.Scene.LoadScene(Define.Scene.Lobby);
    //}

    //public override void OnPlayerEnteredRoom(Player newPlayer)
    //{
    //    print($"OnPlayerEnteredRoom : {newPlayer.NickName}");
    //}

    //#endregion
}
