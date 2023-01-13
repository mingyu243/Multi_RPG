using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager
{
    IRoom _room;
    Player _localPlayer;
    string _startNickName;

    public IRoom Room { get => _room; set => _room = value; }
    public Player LocalPlayer { get => _localPlayer; set => _localPlayer = value; }
    public string StartNickName { get => _startNickName; set => _startNickName = value; }
}
