using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public string id;
    public string name;
    public ItemType type;
    public string description;
    public string path_mesh;
    public string path_image;
}
public enum ItemType
{

}

public class DataManager : MonoBehaviour
{

    public Dictionary<int, ItemData> ItemDictionary = new Dictionary<int, ItemData>();
}
