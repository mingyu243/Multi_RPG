using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

/// <summary>
/// 
/// [참고]
/// 
/// 시네머신 관련.
/// + https://www.youtube.com/watch?v=537B1kJp9YQ
/// 
/// 플레이어 이동 관련.
/// + https://www.youtube.com/watch?v=b1uoLBp2I1w
/// + Photon 데모 스크립트. (ThirdPersonUserControl, ThirdPersonCharacter)
/// 
/// 네트워크 관련.
/// + https://velog.io/@minjujuu/Unity-%ED%8F%AC%ED%86%A4-%EB%84%A4%ED%8A%B8%EC%9B%8C%ED%81%AC
/// 
/// </summary>
public class PlayerController : MonoBehaviourPun, IPunInstantiateMagicCallback
{
    [Header("Automatic Initialize")] // 스크립트에서 자동으로 초기화.
    [SerializeField] Transform _cam;
    [SerializeField] Character _character;

    //[Header("Manual Initialize")] // 인스펙터에서 수동으로 초기화.

    [Header("Inputs")]
    [SerializeField] float _horizontal; // 수평. (좌우)
    [SerializeField] float _vertical; // 수직. (위아래)
    [SerializeField] float _mouseX; // 마우스 좌우.

    [SerializeField] Vector3 _playerMovementInput;
    [SerializeField] Vector3 _playerMouseInput;

    public Character Character
    {
        get { return _character; }
        set { _character = value; }
    }

    void Start()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        _cam = Camera.main.transform;

        Managers.Input.KeyAction -= CheckInput;
        Managers.Input.KeyAction += CheckInput;
    }

    public void OnPossess(Character character)
    {
        if (photonView.IsMine)
        {
            photonView.RPC(nameof(OnPossessRPC), RpcTarget.AllBuffered, character.photonView.ViewID);
        }
    }

    [PunRPC]
    void OnPossessRPC(int viewID)
    {
        _character = Managers.GamePlay.Characters[viewID];
    }


    public void CheckInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _mouseX = Input.GetAxis("Mouse X");

        _playerMovementInput = (_vertical * _cam.forward) + (_horizontal * _cam.right);
        _playerMouseInput = new Vector2(_mouseX, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _character?.PlayRoll();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _character?.PlayJump();
        }
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        // 캐릭터 이동.
        _character?.Move(_playerMovementInput);
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        Managers.GamePlay.AddPlayerController(this);
    }

    private void OnDestroy()
    {
        //Managers.GamePlay.RemovePlayerController(this);
    }
}
