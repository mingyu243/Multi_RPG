using Cinemachine;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerManager
{
    string _inputNickname;
    PlayerController _playerController;

    public string InputNickname { get => _inputNickname; set => _inputNickname = value; }
    public PlayerController PlayerController { get => _playerController; set => _playerController = value; }

}
