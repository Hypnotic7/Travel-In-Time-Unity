using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillFlask : Interactable
{

    public int ItemID;

    public override void Interact()
    {
        var inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        if (inventory == null) return;

        if (inventory.items.Exists(f => f.ID == ItemID))
        {
            inventory.RemoveItem(ItemID);
            inventory.AddItem(7);
        }
    }
}
