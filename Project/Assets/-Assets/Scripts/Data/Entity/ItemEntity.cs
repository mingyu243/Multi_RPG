using System;

public class ItemEntity : IEntity // 테이블과 똑같은 데이터.
{
    public string _id;
    public string name;
    public ItemType type;
    public string description;
    public string path_mesh;
    public string path_image;

    public ItemEntity(string id, string name, string type, string description, string path_mesh, string path_image)
    {
        _id = id;
        this.name = name;
        this.type = (ItemType)Enum.Parse(typeof(ItemType), type);
        this.description = description;
        this.path_mesh = path_mesh;
        this.path_image = path_image;
    }
}

public enum ItemType
{
    EQUIPMENT,

}