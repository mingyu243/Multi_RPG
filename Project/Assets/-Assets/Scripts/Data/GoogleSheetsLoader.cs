using Cysharp.Threading.Tasks;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetsLoader : MonoBehaviour
{
    static string SHEETS_URL = "https://docs.google.com/spreadsheets/d/{0}/gviz/tq?gid={1}";
    static string SHEETS_ID = "1wYGpgtukyGSoozUvHM746XwNSs500977LOwsKdd6pbY";

    static string SHEET_ID_ITEM = "1912785264";
    static string SHEET_ID_EQUIPMENT = "0";
    static string SHEET_ID_ARMOR = "1492396631";
    static string SHEET_ID_WEAPON = "725871172";

    public static async UniTask RequestSheetAsync(
        Dictionary<string, ItemEntity> dic_Item, Dictionary<string, EquipmentEntity> dic_Equipment,
        Dictionary<string, ArmorEntity> dic_Armor, Dictionary<string, WeaponEntity> dic_Weapon
        )
    {
        // 기본 아이템 데이터.
        //await SetItemData(dicItem);

        // 세부 아이템 데이터.
        //await SetEquipmentData(dicItem, dicEquipment);




    }

    static async UniTask SetItemData(Dictionary<string, ItemDTO> dicItem)
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

            dicItem.Add(_id, new ItemDTO(new ItemEntity(_id, name, type, description, path_mesh, path_image)));
        }
    }
    static async UniTask SetEquipmentData(Dictionary<string, ItemDTO> dicItem, Dictionary<string, EquipmentDTO> dicEquipment)
    {
        string downloadText = await GetTextAsync(string.Format(SHEETS_URL, SHEETS_ID, SHEET_ID_EQUIPMENT));

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

            //dicEquipment.Add(_id, new EquipmentDTO(new ItemEntity(_id, name, type, description, path_mesh, path_image)));
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
