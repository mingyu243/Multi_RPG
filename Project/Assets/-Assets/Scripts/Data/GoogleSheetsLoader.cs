using Cysharp.Threading.Tasks;
using SimpleJSON;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetsLoader
{
    static string SHEETS_URL = "https://docs.google.com/spreadsheets/d/{0}/gviz/tq?gid={1}";
    static string SHEETS_ID = "1wYGpgtukyGSoozUvHM746XwNSs500977LOwsKdd6pbY";
    static string SHEET_ID_ITEM = "1912785264";

    static async UniTask RequestSheetAsync(string docId, string gId)
    {
        UniTask taskItem = GetTextAsync(string.Format(SHEETS_URL, SHEETS_ID, SHEET_ID_ITEM));

        JSONNode json = JSON.Parse(www.downloadHandler.text);
        JSONNode rows = json["table"]["rows"];
        for (int i = 0; i < rows.Count; i++)
        {
            string id = GetContentData(rows, i, 0);
            string name = GetContentData(rows, i, 1);
            string type = GetContentData(rows, i, 2);
            string description = GetContentData(rows, i, 3);
            string path_mesh = GetContentData(rows, i, 4);
            string path_image = GetContentData(rows, i, 5);

            //new ItemData()
        }
    }

    static async UniTask<string> GetTextAsync(string uri)
    {
        UnityWebRequest req = UnityWebRequest.Get(uri);
        UnityWebRequest op = await req.SendWebRequest();
        if (req.result == UnityWebRequest.Result.ProtocolError || req.result == UnityWebRequest.Result.ConnectionError)
        {
            yield break;
        }

        Debug.Log(req.downloadHandler.text);

        var op = await req.SendWebRequest();
        return op.downloadHandler.text;
    }

    static string GetContentData(JSONNode rows, int row, int col)
    {
        return rows[row]["c"][col]["v"];
    }

}
