using Cysharp.Threading.Tasks;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetsLoader
{
    static string SHEETS_URL = "https://docs.google.com/spreadsheets/d/{0}/gviz/tq?gid={1}";
    static string SHEETS_ID = "1wYGpgtukyGSoozUvHM746XwNSs500977LOwsKdd6pbY";

    static string SHEET_ID_ITEM = "1912785264";
    static string SHEET_ID_EQUIPMENT = "0";
    static string SHEET_ID_ARMOR = "1492396631";
    static string SHEET_ID_WEAPON = "725871172";

    public static Dictionary<string, ItemEntity> ItemDic = new Dictionary<string, ItemEntity>();
    public static Dictionary<string, EquipmentEntity> EquipmentDic = new Dictionary<string, EquipmentEntity>();
    public static Dictionary<string, ArmorEntity> ArmorDic = new Dictionary<string, ArmorEntity>();
    public static Dictionary<string, WeaponEntity> WeaponDic = new Dictionary<string, WeaponEntity>();

    public static async UniTask LoadSheetData()
    {
        await SetItemData();
        await SetEquipmentData();
        await SetArmorData();
        await SetWeaponData();
    }

    static async UniTask SetItemData()
    {
        string downloadText = await GetTextAsync(string.Format(SHEETS_URL, SHEETS_ID, SHEET_ID_ITEM));

        JSONNode json = JSON.Parse(downloadText);
        JSONNode rows = json["table"]["rows"];
        for (int i = 0; i < rows.Count; i++)
        {
            string _id = GetContentData(rows, i, 0);
            string name = GetContentData(rows, i, 1);
            string type = GetContentData(rows, i, 2);
            string description = GetContentData(rows, i, 3);
            string path_mesh = GetContentData(rows, i, 4);
            string path_image = GetContentData(rows, i, 5);

            ItemDic.Add(_id, new ItemEntity(_id, name, type, description, path_mesh, path_image));
        }
    }

    static async UniTask SetEquipmentData()
    {
        string downloadText = await GetTextAsync(string.Format(SHEETS_URL, SHEETS_ID, SHEET_ID_EQUIPMENT));

        JSONNode json = JSON.Parse(downloadText);
        JSONNode rows = json["table"]["rows"];
        for (int i = 0; i < rows.Count; i++)
        {
            string _id = GetContentData(rows, i, 0);
            string name = GetContentData(rows, i, 1);
            string type = GetContentData(rows, i, 2);

            EquipmentDic.Add(_id, new EquipmentEntity(_id, name, type));
        }
    }

    static async UniTask SetArmorData()
    {
        string downloadText = await GetTextAsync(string.Format(SHEETS_URL, SHEETS_ID, SHEET_ID_ARMOR));

        JSONNode json = JSON.Parse(downloadText);
        JSONNode rows = json["table"]["rows"];
        for (int i = 0; i < rows.Count; i++)
        {
            string _id = GetContentData(rows, i, 0);
            string type = GetContentData(rows, i, 1);

            ArmorDic.Add(_id, new ArmorEntity(_id, type));
        }
    }
    static async UniTask SetWeaponData()
    {
        string downloadText = await GetTextAsync(string.Format(SHEETS_URL, SHEETS_ID, SHEET_ID_WEAPON));

        JSONNode json = JSON.Parse(downloadText);
        JSONNode rows = json["table"]["rows"];
        for (int i = 0; i < rows.Count; i++)
        {
            string _id = GetContentData(rows, i, 0);
            string type = GetContentData(rows, i, 1);
            string combatType = GetContentData(rows, i, 2);

            WeaponDic.Add(_id, new WeaponEntity(_id, type, combatType));
        }
    }

    static async UniTask<string> GetTextAsync(string uri)
    {
        UnityWebRequest req = UnityWebRequest.Get(uri);
        await req.SendWebRequest();

        //if (req.result == UnityWebRequest.Result.ProtocolError || req.result == UnityWebRequest.Result.ConnectionError)
        //{
        //    return null;
        //}

        Debug.Log(req.downloadHandler.text);
        return req.downloadHandler.text;
    }

    static string GetContentData(JSONNode rows, int row, int col)
    {
        return rows[row]["c"][col]["v"];
    }

}
