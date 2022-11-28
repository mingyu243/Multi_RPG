using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : NetworkBehaviour, IMovable
{
    [Header("Automatic Initialize")] // 스크립트에서 자동으로 초기화.
    [SerializeField] UnitMovement _unitMovement;

    void Awake()
    {
        _unitMovement = GetComponent<UnitMovement>();
    }

    public void KeepJumping()
    {
        _unitMovement.KeepJumping();
    }

    public void Move(Vector3 inputMove)
    {
        _unitMovement.Move(inputMove);
    }

    public void PlayJump()
    {
        _unitMovement.PlayJump();
    }

    public void StopJump()
    {
        _unitMovement.StopJump();
    }







}
