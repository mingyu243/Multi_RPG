using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : NetworkBehaviour, IMovable
{
    [Header("Automatic Initialize")] // 스크립트에서 자동으로 초기화.
    [SerializeField] MoveController _moveController;
    [SerializeField] CombatController _combatController;

    void Awake()
    {
        _moveController = GetComponent<MoveController>();
        _combatController = GetComponent<CombatController>();
    }

    public void KeepJumping()
    {
        _moveController.KeepJumping();
    }

    public void Move(Vector3 inputMove)
    {
        _moveController.Move(inputMove);
    }

    public void PlayJump()
    {
        _moveController.PlayJump();
    }

    public void StopJump()
    {
        _moveController.StopJump();
    }







}
