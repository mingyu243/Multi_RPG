using Cysharp.Threading.Tasks;
using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour, INetworkRunnerCallbacks
{
    [SerializeField] NetworkRunner _runner;
    
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
        _runner = this.gameObject.AddComponent<NetworkRunner>();
        _runner.ProvideInput = true;

        await _runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.AutoHostOrClient,
            SessionName = sessionName,
            Scene = Managers.Scene.GetBuildIndex(Define.Scene.Lobby)
        });
    }
    public void LoadScene(string sceneName)
    {
        // MasterClient만 호출해야 함.
        // AutomaticallySyncScene = true 설정으로 이후에 들어오는 사람도 자동으로 이동함.
        //if (PhotonNetwork.IsMasterClient)
        //{
        //    PhotonNetwork.LoadLevel(sceneName);
        //}
    }
    public NetworkObject Spawn(NetworkRunner networkRunner, string prefabPath, Vector3? position = null, Quaternion? rotation = null, PlayerRef? inputAuthority = null)
    {
        return Spawn(networkRunner, Managers.Resource.Load<GameObject>($"Prefabs/{prefabPath}"), position, rotation, inputAuthority);
    }
    public NetworkObject Spawn(NetworkRunner networkRunner, GameObject prefab, Vector3? position = null, Quaternion? rotation = null, PlayerRef? inputAuthority = null)
    {
        return _runner.Spawn(prefab, position, rotation, inputAuthority);
    }

    #region Callbacks
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Managers.LocalPlayer.PlayerRef = player;
        print("OnPlayerJoined");

    }
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        print("OnPlayerLeft");
    }
    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        Managers.Input.OnUpdate();
    }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
    }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
    }
    public void OnConnectedToServer(NetworkRunner runner)
    {
        print("OnConnectedToServer");
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
