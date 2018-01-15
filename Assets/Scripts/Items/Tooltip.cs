using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Items
{
    public class Tooltip : MonoBehaviour
    {
        private Item item;
        private string data;
        private GameObject tooltip;

        void Start()
        {
            tooltip = GameObject.Find("Tooltip");
            tooltip.SetActive(false);
        }

        void Update()
        {
            if (tooltip.activeSelf)
            {
                tooltip.transform.position = Input.mousePosition;
            }
        }

        public void Activate(Item item)
        {
            this.item = item;
           
            ConstructDataString();
            tooltip.SetActive(true);
        }

        public void Deactivate()
        {
            tooltip.SetActive(false);
        }

        public void ConstructDataString()
        {
            data = "<color=#000000>" + item.Title + "</color>\n\n" + item.ID + "";
            tooltip.transform.GetChild(0).GetComponent<Text>().text = data;

        }
    }
}
