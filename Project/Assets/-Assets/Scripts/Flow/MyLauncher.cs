using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class MyLauncher : MonoBehaviour
{
    [SerializeField] TMP_InputField _roomName;
    [SerializeField] TMP_InputField _nickName;

    public void JoinOrCreateRoom() // button event.
    {
        Managers.Network.SetNickName(_nickName.text);
        Managers.Network.JoinOrCreateRoomAsync(_roomName.text).Forget();
    }
}
