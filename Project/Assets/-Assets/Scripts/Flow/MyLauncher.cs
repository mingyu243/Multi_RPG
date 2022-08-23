using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class MyLauncher : MonoBehaviour
{
    [SerializeField] TMP_InputField m_RoomName;
    [SerializeField] TMP_InputField m_NickName;

    public void JoinOrCreateRoom() // button event.
    {
        Managers.Network.SetNickName(m_NickName.text);
        Managers.Network.JoinOrCreateRoomAsync(m_RoomName.text).Forget();
    }
}
