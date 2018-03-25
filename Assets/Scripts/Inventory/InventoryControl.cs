using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Items;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class InventoryControl : MonoBehaviour
    {
        public Transform inventory;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Activate(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Activate(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Activate(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Activate(4);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Activate(5);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                Activate(6);
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                Activate(7);
            }

        }

        private void Activate(int index)
        {
            var itemData = inventory.GetComponent<Inventory>().slots[index - 1].transform.GetChild(1)
                .GetComponent<ItemData>();
            if (itemData != null)
            {
                if (itemData.item.ID == 0)
                    itemData.ActivateTimeWatch();
                if (itemData.item.ID == 8)
                    itemData.ActivateInvisibilityFlask();
                if (itemData.item.ID == 13)
                    itemData.ActivatePuzzle();
            }
            
        }
    }
}
