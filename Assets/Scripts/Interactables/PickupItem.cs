using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable {

    public override void Interact()
    {
        var inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

        if (inventory == null) return;

        inventory.AddItem(2);
        var key = GameObject.Find("Key");
        key.SetActive(false);
    }
}
