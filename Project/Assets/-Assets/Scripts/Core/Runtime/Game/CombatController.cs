using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : NetworkBehaviour
{
    [Header("Automatic Initialize")] // 스크립트에서 자동으로 초기화.
    [SerializeField] AnimationController _animationController;

    public enum CombatType // 지금은 테스트용. 나중엔 하나하나 클래스로 묶는 게 나을듯. 준비, 쏘기 이런식으로.
    {
        None = 0,
        NoWeapon,
        SingleSword,
        Bow
    }

    [Networked(OnChanged = nameof(OnChangedCombatType))] public CombatType CurrCombatType { get; set; }
    public static void OnChangedCombatType(Changed<CombatController> changed) => print($"{changed.Behaviour.CurrCombatType}");

    void Awake()
    {
        _animationController = GetComponentInChildren<AnimationController>();
    }
}
