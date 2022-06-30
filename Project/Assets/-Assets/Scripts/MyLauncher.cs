using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLauncher : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void JoinRandomOrCreateRoom() // button event.
    {
        print("");
    }

    #region 포톤 콜백 함수

    public override void OnConnectedToMaster()
    {
        print("서버 접속 완료.");
    }


    #endregion
}
