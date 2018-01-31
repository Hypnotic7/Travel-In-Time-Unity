using System.Collections.Generic;
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
	        slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(inventoryPanel.transform,false);
	    }
        AddItem(0);
	}

    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);

        if (itemToAdd.Stackable && CheckForItemInInventory(itemToAdd))
        {
            for (int j = 0; j < items.Count; j++)
            {
                if (items[j].ID == id)
                {
                    ItemData data = slots[j].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;

                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().amount = 1;
                    itemObj.GetComponent<ItemData>().slot = i;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.transform.localPosition = Vector2.zero;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    itemObj.name = itemToAdd.Title;
                    break;
                }
            }
        }
            
    }

    public bool CheckForItemInInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
                return true;
        }
        return false;
    }
}
