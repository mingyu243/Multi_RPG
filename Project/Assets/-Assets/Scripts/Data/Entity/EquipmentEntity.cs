using System;

public class EquipmentEntity : IEntity // 테이블과 똑같은 데이터.
{
    public string _id;
    public EquipmentPartType type;

    // 능력치.
    // ex) 레벨 제한, 이동 속도

    public EquipmentEntity(string id, string name, string type)
    {
        _id = id;
        this.type = (EquipmentPartType)Enum.Parse(typeof(EquipmentPartType), type);
    }
}

public enum EquipmentPartType
{
    ARMOR,
    WEAPON,
}