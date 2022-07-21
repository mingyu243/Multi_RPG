using System;

public class ArmorEntity : IEntity // 테이블과 똑같은 데이터.
{
    public string _id;
    public ArmorType type;

    public ArmorEntity(string id, string type)
    {
        _id = id;
        this.type = (ArmorType)Enum.Parse(typeof(ArmorType), type);
    }
}

public enum ArmorType
{
    CLOTH,
    BELT,
    FACE,
    GLOVE,
    HAT,
    HAIR,
    SHOE,
    SHOULDERPAD,

    BACKPACK,
}