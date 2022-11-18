using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Chat : UI_Base
{
    enum Texts
    {
        ChatLog,
    }

    enum InputFields
    {
        ChatInputField,
    }

    public override void Init()
    {
        Bind<TMP_Text>(typeof(Texts));
        Bind<TMP_InputField>(typeof(InputFields));

        Get<TMP_Text>((int)Texts.ChatLog).text = string.Empty;

        Managers.Input.KeyAction -= CheckInput;
        Managers.Input.KeyAction += CheckInput;
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ToggleActive();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void ToggleActive()
    {
        //Get<TMP_InputField>((int)InputFields.ChatInputField).ActivateInputField();

        TMP_InputField inputField = Get<TMP_InputField>((int)InputFields.ChatInputField);
        print(inputField.isFocused);
        if (inputField.isFocused)
        {
            string message = inputField.text;
            if(message != string.Empty)
            {
                Managers.LocalPlayer.PlayerController.SendChatMessage(message);
                inputField.text = string.Empty;
            }
        }
        inputField.ActivateInputField();
    }

    public void AddMessage(string nickname, string message)
    {
        Get<TMP_Text>((int)Texts.ChatLog).text += $"{nickname} : {message}\n";
    }
}
