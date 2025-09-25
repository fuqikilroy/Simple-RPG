using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image iconImage;
    public Text nameText;
    public Text typeText;

    public ItemSO itemSO;

    public void InitItem(ItemSO itemSO)
    {
        string type = "";
        switch (itemSO.itemType)
        {
            case ItemType.Weapon:
                type = "ÎäÆ÷"; break;
            case ItemType.Consumable:
                type = "¿ÉÏûºÄÆ·"; break;
        }

        iconImage.sprite = itemSO.icon;
        nameText.text = itemSO.name;
        typeText.text = type;
        this.itemSO = itemSO;
    }

    public void OnClick()
    {
        InventoryUI.Instance.OnItemClick(itemSO,this);
    }
}
