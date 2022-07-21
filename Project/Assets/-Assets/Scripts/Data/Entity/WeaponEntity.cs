using System;

public class WeaponEntity : IEntity // 테이블과 똑같은 데이터.
{
    public string _id;
    public WeaponType type;
    public CombatType combatType;

    public WeaponEntity(string id, string type, string combatType)
    {
        _id = id;
        this.type = (WeaponType)Enum.Parse(typeof(WeaponType), type);
        this.combatType = (CombatType)Enum.Parse(typeof(CombatType), combatType);
    }
}

public enum WeaponType
{

}

public enum CombatType
{

}