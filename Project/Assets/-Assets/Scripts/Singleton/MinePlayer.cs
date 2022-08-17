using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePlayer : SingletonMono<MinePlayer>
{
    [SerializeField] GameObject m_Camera;
    [SerializeField] CinemachineVirtualCamera m_CVC;

    InputManager _input = new InputManager();

    public static InputManager Input { get { return Instance._input; } }


    void Start()
    {
        PlayerController pc = Managers.Resource.Load<GameObject>("PlayerController").GetComponent<PlayerController>();
        Character c = Managers.Resource.Load<GameObject>("Character").GetComponent<Character>();

        pc.SetCamera(m_Camera, m_CVC);
        pc.OnPossess(c);
    }

    private void Update()
    {
        
    }
}
