using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManager
{
    static Dictionary<string, Data.Armor> m_ArmorDic = new Dictionary<string, Data.Armor>();
    static Dictionary<string, Data.Weapon> m_WeaponDic = new Dictionary<string, Data.Weapon>();

    public static Dictionary<string, Data.Armor> ArmorDic { get => m_ArmorDic; }
    public static Dictionary<string, Data.Weapon> WeaponDic { get => m_WeaponDic; }

    public async UniTaskVoid Init()
    {
        // 데이터만 싹 가져옴.
        await GoogleSheetsLoader.LoadSheetData();

        MakeArmorDTO();
        MakeWeaponDTO();

        //print("데이터 로딩 끝.");
    }

    void MakeArmorDTO()
    {
        m_ArmorDic.EnsureCapacity(GoogleSheetsLoader.ArmorDic.Count);
        foreach (KeyValuePair<string, ArmorEntity> pair in GoogleSheetsLoader.ArmorDic)
        {
            string k = pair.Key;
            m_ArmorDic.Add(k, new Data.Armor(
                GoogleSheetsLoader.ItemDic[k],
                GoogleSheetsLoader.EquipmentDic[k],
                GoogleSheetsLoader.ArmorDic[k])
                );
        }
    }
    void MakeWeaponDTO()
    {
        m_WeaponDic.EnsureCapacity(GoogleSheetsLoader.WeaponDic.Count);
        foreach (KeyValuePair<string, WeaponEntity> pair in GoogleSheetsLoader.WeaponDic)
        {
            string k = pair.Key;
            m_WeaponDic.Add(k, new Data.Weapon(
                GoogleSheetsLoader.ItemDic[k],
                GoogleSheetsLoader.EquipmentDic[k],
                GoogleSheetsLoader.WeaponDic[k])
                );
        }
    }

    public void CombineDataToMakeDTO()
    {

    }
}
