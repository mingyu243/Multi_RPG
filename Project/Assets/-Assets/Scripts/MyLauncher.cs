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

    #region ���� �ݹ� �Լ�

    public override void OnConnectedToMaster()
    {
        print("���� ���� �Ϸ�.");
    }


    #endregion
}
