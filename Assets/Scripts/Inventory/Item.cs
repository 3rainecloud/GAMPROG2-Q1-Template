using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    InventoryManager manage;

    public override void Interact()
    {
        // TODO: Add the item to the inventory. Make sure to destroy the prefab once the item is collected

        //manage.enabled = true;
        Destroy(gameObject);
    }
}
