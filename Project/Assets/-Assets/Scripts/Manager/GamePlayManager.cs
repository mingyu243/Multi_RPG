using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager
{
    Dictionary<int, PlayerController> _playerControllers = new Dictionary<int, PlayerController>();
    Dictionary<int, Character> _characters = new Dictionary<int, Character>();

    public Dictionary<int, PlayerController> PlayerControllers { get { return _playerControllers; } }
    public Dictionary<int, Character> Characters { get { return _characters; } }

    //public void AddPlayerController(PlayerController pc)
    //{
    //    _playerControllers.Add(pc.photonView.ViewID, pc);
    //}
    //public void RemovePlayerController(PlayerController pc)
    //{
    //    _playerControllers.Remove(pc.photonView.ViewID);
    //}

    //public void AddCharacter(Character c)
    //{
    //    _characters.Add(c.photonView.ViewID, c);
    //}
    //public void RemoveCharacter(Character c)
    //{
    //    _characters.Remove(c.photonView.ViewID);
    //}
}
