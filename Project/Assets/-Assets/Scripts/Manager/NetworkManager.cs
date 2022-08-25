using Cysharp.Threading.Tasks;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] bool isConnectedToMaster;

    public bool IsConnect { get { return isConnectedToMaster; } }

    public void Init()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void SetNickName(string nickName)
    {
        PhotonNetwork.LocalPlayer.NickName = nickName;
    }

    public void JoinOrCreateRoom(string roomName)
    {
        PhotonNetwork.JoinOrCreateRoom(roomName, null, null);
    }
    public async UniTask JoinOrCreateRoomAsync(string roomName)
    {
        await UniTask.WaitUntil(() => isConnectedToMaster == true);
        PhotonNetwork.JoinOrCreateRoom(roomName, null, null);
    }

    public void LoadScene(string sceneName)
    {
        // MasterClient만 호출해야 함.
        // AutomaticallySyncScene = true 설정으로 이후에 들어오는 사람도 자동으로 이동함.
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(sceneName);
        }
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject go = PhotonNetwork.Instantiate($"Prefabs/{path}", Vector3.zero, Quaternion.identity);
   //     go.transform.SetParent(parent);

        return go;
    }

    public PhotonView GetPhotonView(int viewID)
    {
        return PhotonNetwork.GetPhotonView(viewID);
    }

    #region 포톤 콜백 함수

    public override void OnConnectedToMaster()
    {
        isConnectedToMaster = true;
        print("OnConnectedToMaster");
    }

    public override void OnCreatedRoom()
    {
        print("OnCreateRoom");
    }

    public override void OnJoinedRoom()
    {
        print("OnJoinedRoom");

        Managers.Scene.LoadScene(Define.Scene.Lobby);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print($"OnPlayerEnteredRoom : {newPlayer.NickName}");
    }

    #endregion
}
