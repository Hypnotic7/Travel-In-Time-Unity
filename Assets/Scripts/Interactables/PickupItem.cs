using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class PickupItem : Interactable
{
    public int ItemID;
    private Color startcolor;


    void Start()
    {
        if (gameObject.name == "vinyl" && GameplayChecker.VinylPickUpSouth)
           Destroy(gameObject);
        if (gameObject.name == "vinyl1" && GameplayChecker.VinylPickUpWest)
            Destroy(gameObject);
        if (gameObject.name == "vinyl2" && GameplayChecker.VinylPickUpEast)
            Destroy(gameObject);
        if (gameObject.name == "vinyl3" && GameplayChecker.VinylPickUpNorthEast)
            Destroy(gameObject);
    }

    void OnMouseEnter()
    {

        startcolor = this.GetComponent<Renderer>().material.color;
        this.GetComponent<Renderer>().material.color = Color.magenta;

    }
    void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = startcolor;
    }

    public override void Interact()
    {
        var inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

        if (inventory == null) return;


        if (inventory.items.Exists(f => f.ID == ItemID))
        {
            if (ItemID == 9)
            {
                inventory.AddItem(ItemID);
                if (gameObject.name == "vinyl")
                    GameplayChecker.VinylPickUpSouth = true;
                else if (gameObject.name == "vinyl1")
                    GameplayChecker.VinylPickUpWest = true;
                else if (gameObject.name == "vinyl2")
                    GameplayChecker.VinylPickUpEast = true;
                else if (gameObject.name == "vinyl3")
                    GameplayChecker.VinylPickUpNorthEast = true;

                Destroy(this.gameObject);
            }
        }else if (!inventory.items.Exists(f => f.ID == ItemID))
        {
            inventory.AddItem(ItemID);
            if (ItemID == 6)
                Destroy(GameObject.Find("Flask"));
            if (ItemID == 9)
            {
                if (gameObject.name == "vinyl")
                    GameplayChecker.VinylPickUpSouth = true;
                else if (gameObject.name == "vinyl1")
                    GameplayChecker.VinylPickUpWest = true;
                else if (gameObject.name == "vinyl2")
                    GameplayChecker.VinylPickUpEast = true;
                else if (gameObject.name == "vinyl3")
                    GameplayChecker.VinylPickUpNorthEast = true;
                Destroy(gameObject);
            }
              
            
        }



    }
}
