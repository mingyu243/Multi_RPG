using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

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

    TMP_Text _chatLog;
    TMP_InputField _chatInputField;

    public override void Init()
    {
        Bind<TMP_Text>(typeof(Texts));
        Bind<TMP_InputField>(typeof(InputFields));

        _chatLog = Get<TMP_Text>((int)Texts.ChatLog);
        _chatLog.text = string.Empty;

        _chatInputField = Get<TMP_InputField>((int)InputFields.ChatInputField);
        _chatInputField.onSubmit.RemoveListener(SendInputMessage);
        _chatInputField.onSubmit.AddListener(SendInputMessage);
        //_chatInputField.onSelect.AddListener((s)=>print("onSelect"));
        //_chatInputField.onDeselect.AddListener((s) => print("onDeselect"));

        Managers.Input.KeyAction -= CheckInput;
        Managers.Input.KeyAction += CheckInput;
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ToggleInputField();
        }
    }

    void Start()
    {
        Init();
    }

    private void ToggleInputField()
    {
        if(EventSystem.current.currentSelectedGameObject == _chatInputField.gameObject)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            _chatInputField.ActivateInputField();
        }
    }

    public void SendInputMessage(string inputMessage)
    {
        if (inputMessage != string.Empty)
        {
            Managers.LocalPlayer.PlayerController.SendChatMessage(inputMessage);
            _chatInputField.text = string.Empty;
        }
    }

    public void AddMessage(string nickname, string message)
    {
        _chatLog.text += $"{nickname} : {message}\n";
    }
}
