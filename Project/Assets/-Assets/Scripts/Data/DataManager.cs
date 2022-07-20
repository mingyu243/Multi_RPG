using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    public Dictionary<string, ItemDTO> ItemDictionary = new Dictionary<string, ItemDTO>();
    public Dictionary<string, ItemDTO> EquipmentDictionary = new Dictionary<string, ItemDTO>();

    private void Awake()
    {
        //Init().Forget();
    }

    public async UniTaskVoid Init()
    {
        //await GoogleSheetsLoader.RequestSheetAsync(ItemDictionary, );
        print("데이터 로딩 끝.");
    }
}
