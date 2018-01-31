using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Interactables.Pictures
{
    public class PictureSlot : MonoBehaviour, IDropHandler
    {
        private PicturesManager picturesManager;
        public int ID;

        void Start()
        {
            picturesManager = GameObject.Find("PicturesPanel").GetComponent<PicturesManager>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            var droppedImage = eventData.pointerDrag.GetComponent<PictureImage>();

            picturesManager = GameObject.Find("PicturesPanel").GetComponent<PicturesManager>();
            if (picturesManager.Pictures[this.ID].ID == -1)
            {
                for (int i = 0; i < picturesManager.Pictures.Count; i++)
                {
                    picturesManager.Pictures[i].ID = -1;
                }
                Debug.Log("Picture SLot ID:" + ID);
                //picturesManager.Pictures[droppedImage.SlotNumber] = new Picture();
                picturesManager.Pictures[ID] = droppedImage.Picture;
                droppedImage.SlotNumber = ID;
            }
            else
            {
                Debug.Log("Picture SLot ID:" + ID);
                Transform picture = this.transform.GetChild(0);
                picture.GetComponent<PictureImage>().SlotNumber = droppedImage.SlotNumber;
                picture.transform.SetParent(picturesManager.ImageSlots[droppedImage.SlotNumber].transform);
                picture.transform.position = picturesManager.ImageSlots[droppedImage.SlotNumber].transform.position;

                droppedImage.SlotNumber = ID;
                droppedImage.transform.SetParent(this.transform);
                droppedImage.transform.position = this.transform.position;
                picturesManager.ImageSlots[ID].transform.GetChild(0).GetComponent<PictureImage>().SlotNumber =
                    droppedImage.SlotNumber;
                
                picturesManager.PictureSlots[droppedImage.SlotNumber].ID = picture.GetComponent<PictureImage>().SlotNumber;
                picturesManager.Pictures[ID].ID = droppedImage.SlotNumber;
                picturesManager.PictureSlots[droppedImage.SlotNumber] = picture.GetComponent<PictureSlot>();
                this.ID = droppedImage.SlotNumber;
                //picturesManager.Counter++;
            }
        }
    }
}
