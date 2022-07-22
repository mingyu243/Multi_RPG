using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    static Dictionary<string, ItemEntity> m_Dic_ItemEntity = new Dictionary<string, ItemEntity>();
    static Dictionary<string, EquipmentEntity> m_Dic_EquipmentEntity = new Dictionary<string, EquipmentEntity>();
    static Dictionary<string, ArmorEntity> m_Dic_ArmorEntity = new Dictionary<string, ArmorEntity>();
    static Dictionary<string, WeaponEntity> m_Dic_WeaponEntity = new Dictionary<string, WeaponEntity>();

    static Dictionary<string, ArmorDTO> m_Dic_ArmorDTO = new Dictionary<string, ArmorDTO>();
    static Dictionary<string, WeaponDTO> m_Dic_WeaponDTO = new Dictionary<string, WeaponDTO>();

    public static Dictionary<string, ArmorDTO> ArmorDic { get => m_Dic_ArmorDTO; }

    private void Awake()
    {
        //Init().Forget();
    }

    public async UniTaskVoid Init()
    {
        // 데이터만 싹 가져옴.
        await GoogleSheetsLoader.RequestSheetAsync(m_Dic_ItemEntity, m_Dic_EquipmentEntity, m_Dic_ArmorEntity, m_Dic_WeaponEntity);

        // 데이터들을 클래스에 맞게 조합해서 정리해줌.
        CombineEntityToMakeDTO();

        print("데이터 로딩 끝.");
    }

    public void CombineEntityToMakeDTO()
    {
        MakeDTO<ArmorDTO, ArmorEntity>(m_Dic_ArmorDTO, m_Dic_ArmorEntity);

        m_Dic_ArmorDTO.EnsureCapacity(m_Dic_ArmorEntity.Count);
        foreach (KeyValuePair<string, ArmorEntity> pair in m_Dic_ArmorEntity)
        {
            string k = pair.Key;
            m_Dic_ArmorDTO.Add(k, new ArmorDTO(m_Dic_ItemEntity[k], m_Dic_EquipmentEntity[k], m_Dic_ArmorEntity[k]));
        }

        m_Dic_WeaponDTO.EnsureCapacity(m_Dic_WeaponEntity.Count);
        foreach (KeyValuePair<string, WeaponEntity> pair in m_Dic_ArmorEntity)
        {
            string k = pair.Key;
            m_Dic_WeaponDTO.Add(k, new EquipmentDTO(m_Dic_ItemEntity[k], m_Dic_EquipmentEntity[k], m_Dic_WeaponEntity[k]));
        }
    }

    private void MakeDTO<T1, T2>(Dictionary<string, T1> dicDTO, Dictionary<string, T2> dicEntity, ) 
        where T1 : IDTO, new()
        where T2 : IEntity
    {
        dicDTO.EnsureCapacity(dicEntity.Count);

        foreach(KeyValuePair<string, T2> pair in dicEntity)
        {
            string k = pair.Key;
            dicDTO.Add(k, new T1());
        }
    }
}
