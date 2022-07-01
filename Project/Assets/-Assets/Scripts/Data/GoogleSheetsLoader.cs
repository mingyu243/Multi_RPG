using SimpleJSON;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class GoogleSheetsLoader : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(RequestSheets("1wYGpgtukyGSoozUvHM746XwNSs500977LOwsKdd6pbY", "1912785264"));
    }

    public void Request(string docId, string gId)
    {
        StartCoroutine(RequestSheets(docId, gId));
    }

    IEnumerator RequestSheets(string docId, string gId)
    {
        UnityWebRequest www = UnityWebRequest.Get($"https://docs.google.com/spreadsheets/d/{docId}/gviz/tq?gid={gId}");

        yield return www.SendWebRequest();

        if(www.result == UnityWebRequest.Result.ProtocolError || www.result == UnityWebRequest.Result.ConnectionError)
        {
            yield break;
        }

        print(www.downloadHandler.text);

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

            new ItemData()
        }
    }

    private string GetContentData(JSONNode rows, int row, int col)
    {
        return rows[row]["c"][col]["v"];
    }

}
