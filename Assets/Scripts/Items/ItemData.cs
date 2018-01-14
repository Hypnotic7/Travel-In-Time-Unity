using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Items
{
    public class ItemData : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler
    {
        public Item item;
        public int amount;


        public void OnPointerDown(PointerEventData eventData)
        {
            if (item.ID != -1)
            {
                
                this.transform.position = eventData.position;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log(item.ID);
            if (item.ID != -1)
            {
                this.transform.position = eventData.position;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            throw new NotImplementedException();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log(item.ID);
            if (item.ID != -1)
            {
                this.transform.position = eventData.position;
            }
        }
    }
}
