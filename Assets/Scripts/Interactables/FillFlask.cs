using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Inventory;
using UnityEngine;

public class FillFlask : Interactable
{

    public int ItemID;

    private Color startcolor;


    void OnMouseEnter()
    {

        startcolor = this.transform.GetComponent<Renderer>().material.color;
        this.transform.GetComponent<Renderer>().material.color = Color.magenta;
    }
    void OnMouseExit()
    {
        this.transform.GetComponent<Renderer>().material.color = startcolor;
    }
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
