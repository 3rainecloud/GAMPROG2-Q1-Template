using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private ItemData itemData;
    public Image itemIcon;

    public void SetItem(ItemData data)
    {
        /* TODO
           Set the item data the and icons here */

        if (itemData.id == "Sword")
        {
            this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = itemData.icon;
        }
        else if (itemData.id == "Shield")
        {
            this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = itemData.icon;
        }
        else if (itemData.id == "HP Potion")
        {
            this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = itemData.icon;
        }
    }

    public void UseItem()
    {
        /* TODO
           Reset the item data and the icons here */

            InventoryManager.Instance.UseItem(itemData);
    }

    public bool HasItem()
    {
        return itemData != null;
    }
}
