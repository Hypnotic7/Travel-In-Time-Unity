using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    public bool ContainsKey;
    public bool OpenClose;
    public bool IsTriggered;
    public int counter;
	// Use this for initialization
	void Start () {
	    IsTriggered = false;
	    ContainsKey = false;
	    counter = 0;
    }

    public bool CheckForKey()
    {
        var inv = GameObject.Find("Inventory").GetComponent<Inventory>();

        if (inv != null)
        {
            foreach (var item in inv.items)
            {
                if (item.ID == 3)
                {
                    ContainsKey = true;
                }
            }
        }
        return ContainsKey;

    }

    public override void Interact()
    {
        Debug.Log("Chest was clicked");
        IsTriggered = true;

        if (CheckForKey())
        {
            if (IsTriggered)
            {
                if (ContainsKey)
                {
                    var inv = GameObject.Find("Inventory").GetComponent<Inventory>();
                    if (OpenClose && counter != 0)
                    {
                        Debug.Log("Chest Open: " + OpenClose);

                        transform.Rotate(60,0 , 0, Space.Self);
                        OpenClose = !OpenClose;
                        if (!inv.items.Exists(f => f.ID == 4))
                        {
                            inv.AddItem(4);
                        }
                    }
                    else if (!OpenClose)
                    {
                        Debug.Log("Chest Closed: " + OpenClose);
                        transform.Rotate(-60, 00, 0, Space.Self);
                        OpenClose = !OpenClose;
                        IsTriggered = false;
                        if (!inv.items.Exists(f => f.ID == 4))
                        {
                            inv.AddItem(4);
                        }
                    }
                    counter++;
                }
            }

        }
    }

}
