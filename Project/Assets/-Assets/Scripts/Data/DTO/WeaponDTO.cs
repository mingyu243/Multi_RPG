using System;

public class WeaponDTO : EquipmentDTO // 프로그래밍에서 사용할 데이터.
{
    private WeaponEntity weapon;

    public WeaponDTO(ItemEntity item, EquipmentEntity equipment, WeaponEntity weapon) : base(item, equipment)
    {
        this.weapon = weapon;
    }

    public WeaponType WeaponType { get => weapon.type; }
    public CombatType CombatType { get => weapon.combatType; }
}