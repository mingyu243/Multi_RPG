using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_GamePlay : UI_Scene
{
    enum GameObjects
    {
        UI_Chat,
    }

    UI_Chat UI_Chat => Get<UI_Chat>((int)GameObjects.UI_Chat);

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<UI_Chat>(typeof(GameObjects));
    }

    public void AddChatMessage(string nickname, string message)
    {
        UI_Chat.AddMessage(nickname, message);
    }
}
