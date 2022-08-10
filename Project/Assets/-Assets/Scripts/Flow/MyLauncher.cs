using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyLauncher : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField m_RoomName;
    [SerializeField] TMP_InputField m_PlayerName;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void JoinOrCreateRoom() // button event.
    {
        string roomName = m_RoomName.text;
        string playerName = m_PlayerName.text;

        PhotonNetwork.LocalPlayer.NickName = playerName;

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
