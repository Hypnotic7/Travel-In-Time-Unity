using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Assets.Scripts.Items;
using Items;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
     public GameObject inventoryPanel;
    public GameObject slotPanel;
    public ItemDatabase database;

    public GameObject inventorySlot;
    public GameObject inventoryItem;
    //public GameObject backgroundPanel;



    public const int slotAmount = 5;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>(); 

	// Use this for initialization
	void Start ()
	{
	    database = GetComponent<ItemDatabase>();
        
	    inventoryPanel = GameObject.Find("Inventory");
	    

        for (int i = 0; i < slotAmount; i++)
	    {
            items.Add(new Item());
	        slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(inventoryPanel.transform,false);
	    }
        AddItem(0);
        AddItem(1);

	}

    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == -1)
            {
                items[i] = itemToAdd;
               
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.transform.localPosition = Vector2.zero;
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                
                itemObj.transform.localScale = new Vector3(0.8f,0.8f,0.8f);
                itemObj.name = itemToAdd.Title;
                break;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
