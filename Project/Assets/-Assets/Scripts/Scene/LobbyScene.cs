using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    [Header("Manual Initialize")] // �ν����Ϳ��� �������� �ʱ�ȭ.
    [SerializeField] Camera _camera;
    [SerializeField] CinemachineVirtualCamera _cvc;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Lobby;

        if (Managers.Network.IsConnect)
        {
            Managers.LocalPlayer.PlayerController = Managers.LocalPlayer.CreatePlayerController();
            Managers.LocalPlayer.PlayerController.OnPossess(Managers.LocalPlayer.CreateCharacter());

            _cvc.Follow = Managers.LocalPlayer.PlayerController.Character.transform;
        }
    }

    public override void Clear()
    {
        throw new System.NotImplementedException();
    }
}
