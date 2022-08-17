using Cysharp.Threading.Tasks;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
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

    #region 포톤 콜백 함수

    public override void OnConnectedToMaster()
    {
        print("OnConnectedToMaster");
    }

    public override void OnCreatedRoom()
    {
        print("OnCreateRoom");
    }

    public override void OnJoinedRoom()
    {
        print("OnJoinedRoom");

        PhotonNetwork.LoadLevel("BasicScene");
    }

    #endregion
}
