using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : NetworkBehaviour /*Pun, IPunInstantiateMagicCallback, IPunObservable*/
{
    [Header("Automatic Initialize")] // 스크립트에서 자동으로 초기화.
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] AnimationController _animationController;

    [Header("Manual Initialize")] // 인스펙터에서 수동으로 초기화.
    [SerializeField] LayerMask _checkOnGroundedLayer;

    [Header("Inputs")] // 입력받은 값.
    [SerializeField] Vector3 _inputMove;
    [SerializeField] Vector3 _moveXZ;
    [SerializeField] float _forwardPower;

    [Header("Stats")] // 능력. 
    [SerializeField] float _moveSpeed = 7f;
    [SerializeField] float _startJumpPower = 5f; // 기본 점프.
    [SerializeField] float _keepJumpPowerMax = 10f; // 점프 힘의 최대.
    [SerializeField] float _keepJumpTime = 0.5f;
    [SerializeField] float _rollPower = 12f;
    [SerializeField] float _checkOnGroundedLength = 0.3f;

    [Header("States")] // 상태.
    [SerializeField] bool _isRolling;
    [SerializeField] bool _onGrounded;
    [SerializeField] bool _canKeepJump;
    [SerializeField] float _currKeepJumpTime = 0f;
    [SerializeField] float _currJumpPower = 0f;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animationController = GetComponentInChildren<AnimationController>();
    }

    public void PlayRoll()
    {
        if(!CanRoll())
        {
            return;
        }

        DirectRotate(); // 원하는 방향으로 즉시 회전.

        _rigidbody.AddForce(transform.forward * _rollPower + Vector3.up * -Physics.gravity.y, ForceMode.Impulse);
        _animationController.Roll();
    }

    public void PlayJump()
{
        if (!CanJump())
        {
            return;
        }

        _canKeepJump = true;
        _currKeepJumpTime = 0.0f;
        _currJumpPower = _startJumpPower;
        _animationController.Jump();
    }

    public void KeepJumping()
    {
        if (!_canKeepJump)
        {
            return;
        }
        if (_currKeepJumpTime > _keepJumpTime) // 시간 다 되면 끝.
        {
            _rigidbody.velocity = Vector3.up * _keepJumpPowerMax; // 마지막 끝 힘까지 넣어줌.

            _canKeepJump = false;
            return;
        }

        _currKeepJumpTime += Time.deltaTime;
        _currJumpPower = Mathf.Lerp(_startJumpPower, _keepJumpPowerMax, _currKeepJumpTime / _keepJumpTime); // 시간에 비례해 min ~ max 힘을 넣어줌.

        //_rigidbody.AddForce(, ForceMode.Impulse);
        _rigidbody.velocity = Vector3.up * _currJumpPower;
    }
    public void StopJumping()
    {
        _canKeepJump = false;
    }


    public void Update()
    {
        _onGrounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, _checkOnGroundedLength, _checkOnGroundedLayer);
        _animationController.OnGrounded(_onGrounded);

        _isRolling = _animationController.IsRolling();
    }

    public void Move(Vector3 inputMove)
    {
        _inputMove = inputMove;

        // 앞으로 가는 속력 구하기.
        _forwardPower = Mathf.Clamp(_inputMove.magnitude, 0, 1); // 대각선으로 갈 때, 빨라지는 것을 방지.
        _animationController.Move(_forwardPower);

        // 이동하기.
        if ((_forwardPower > 0) && CanMove())
        {
            _moveXZ = new Vector3(_inputMove.x, 0, _inputMove.z); // Y축을 제외한 방향 구하기.
            _moveXZ.Normalize();

            //transform.position += (m_MoveXZ * m_MoveSpeed) * m_ForwardPower * Time.deltaTime;
            _rigidbody.MovePosition(transform.position + (_moveXZ * _moveSpeed) * _forwardPower * Runner.DeltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveXZ), 0.3f);
        }
    }

    private void DirectRotate()
    {
        if (_moveXZ.sqrMagnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(_moveXZ);
        }
    }

    private bool CanMove()
    {
        return (_isRolling == false);
    }

    private bool CanRoll()
    {
        return (_isRolling == false);
    }

    private bool CanJump()
    {
        return (_onGrounded == true);
    }

    //public void OnPhotonInstantiate(PhotonMessageInfo info)
    //{
    //    Managers.GamePlay.AddCharacter(this);
    //}

    //private void OnDestroy()
    //{
    //    //Managers.SpawnedObject.RemoveCharacter(this);
    //}

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    //if(stream.IsWriting) // 내 데이터.
    //    //{
    //    //    stream.
    //    //}
    //    //else // 받는 데이터.
    //    //{

    //    //}
    //}
}
