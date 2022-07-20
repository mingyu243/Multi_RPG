using System;

public class ItemEntity // 테이블과 똑같은 데이터.
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

}

public class ItemDTO // 프로그래밍에서 사용할 데이터.
{
    private ItemEntity item;

    public ItemDTO(ItemEntity item)
    {
        this.item = item;
    }

    public string Id { get => item._id; }
    public string Name { get => item.name; }
    public ItemType Type { get => item.type; }
    public string Description { get => item.description; }
    public string PathMesh { get => item.path_mesh; }
    public string PathImage { get => item.path_image; }
}


