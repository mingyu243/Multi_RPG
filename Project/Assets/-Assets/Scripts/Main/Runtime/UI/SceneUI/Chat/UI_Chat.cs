using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

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

    TMP_Text ChatLog => Get<TMP_Text>((int)Texts.ChatLog);
    TMP_InputField ChatInputField => Get<TMP_InputField>((int)InputFields.ChatInputField);

    PlayerChat Chat => Managers.GamePlay.LocalPlayer.Chat;

    public override void Init()
    {
        Bind<TMP_Text>(typeof(Texts));
        Bind<TMP_InputField>(typeof(InputFields));

        ChatLog.text = string.Empty;

        ChatInputField.onSubmit.RemoveListener(SendInputMessage);
        ChatInputField.onSubmit.AddListener(SendInputMessage);

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
        if(EventSystem.current.currentSelectedGameObject == ChatInputField.gameObject)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            ChatInputField.ActivateInputField();
        }
    }

    public void SendInputMessage(string inputMessage)
    {
        if (inputMessage != string.Empty)
        {
            Chat.Chat(inputMessage);
            ChatInputField.text = string.Empty;
        }
    }

    public void AddMessage(string nickname, string message)
    {
        ChatLog.text += $"{nickname} : {message}\n";
    }
}
