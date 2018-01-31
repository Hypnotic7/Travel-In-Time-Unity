using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Interactables.Pictures
{
    public class PictureImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        private Vector2 _offset;
        public Picture Picture { get; set; }
        private PicturesManager _picturesManager;
        public int SlotNumber;

        void Start()
        {
            _picturesManager = GameObject.Find("PicturesPanel").GetComponent<PicturesManager>();

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (Picture.ID != -1)
            {
                _offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
                this.transform.position = eventData.position - _offset;
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
           
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (Picture.ID != -1)
            {
                this.transform.position = eventData.position - _offset;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log(Picture.ID);
            this.transform.SetParent(_picturesManager.ImageSlots[SlotNumber].transform);
            this.transform.position = _picturesManager.ImageSlots[SlotNumber].transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            _picturesManager.Counter++;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Picture ID: " + Picture.ID);
            Debug.Log("Picture Slot ID: " + _picturesManager.ImageSlots[SlotNumber].transform.GetComponent<PictureSlot>().ID);
        }
 
               

       

        
    }
}
