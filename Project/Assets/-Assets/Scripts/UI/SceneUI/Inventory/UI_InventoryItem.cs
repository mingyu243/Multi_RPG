using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_InventoryItem : UI_Base
{
    enum Texts
    {
        ItemNameText,
    }

    enum Images
    {
        ItemIcon,
    }

    string _name;

    public override void Init()
    {
        Bind<TMP_Text>(typeof(Texts));
        Bind<Image>(typeof(Images));

        Get<TMP_Text>((int)Texts.ItemNameText).text = _name;
        Get<Image>((int)Images.ItemIcon).gameObject.BindEvent((PointerEventData) => Debug.Log($"아이템 클릭! {name}"));
    }

    void Start()
    {
        Init();
    }

    public void SetInfo(string name)
    {
        _name = name;
    }
}
