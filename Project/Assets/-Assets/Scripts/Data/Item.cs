using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEntity // 테이블과 똑같은 데이터.
{
    public string _id;
    public string name;
    public ItemType type;
    public string description;
    public string path_mesh;
    public string path_image;
}

public class ItemDTO // 프로그래밍에서 사용할 데이터.
{
    private ItemEntity entity;

    public string Id { get => entity._id; }
    public string Name { get => entity.name; }
    public ItemType Type { get => entity.type; }
    public string Description { get => entity.description; }
    public string PathMesh { get => entity.path_mesh; }
    public string PathImage { get => entity.path_image; }
}

public enum ItemType
{

}
