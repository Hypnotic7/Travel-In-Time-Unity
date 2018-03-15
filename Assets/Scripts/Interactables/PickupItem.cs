using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{
    public int ItemID;
    public override void Interact()
    {
        var inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

        if (inventory == null) return;

        if (!inventory.items.Exists(f => f.ID == ItemID))
        {
            inventory.AddItem(ItemID);
            if(ItemID == 6)
            Destroy(GameObject.Find("Flask"));
            if (ItemID == 9)
                Destroy(this.gameObject);

        }
        else if (inventory.items.Exists(f => f.ID == ItemID))
        {
            inventory.AddItem(ItemID);
            if (ItemID == 9)
                Destroy(this.gameObject);
        }
        
    }
}
