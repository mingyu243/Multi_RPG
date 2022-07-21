using System;

public class ArmorDTO : EquipmentDTO // 프로그래밍에서 사용할 데이터.
{
    private ArmorEntity armor;

    public ArmorDTO(ItemEntity item, EquipmentEntity equipment, ArmorEntity armor) : base(item, equipment)
    {
        this.armor = armor;
    }

    public ArmorType ArmorType { get => armor.type; }
}