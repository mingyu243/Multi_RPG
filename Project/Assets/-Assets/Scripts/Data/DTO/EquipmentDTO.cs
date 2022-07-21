using System;

public class EquipmentDTO : ItemDTO // 프로그래밍에서 사용할 데이터.
{
    private EquipmentEntity equipment;

    public EquipmentDTO(ItemEntity item, EquipmentEntity equipment) : base(item)
    {
        this.equipment = equipment;
    }

    public EquipmentPartType EquipmentType { get => equipment.type; }
}