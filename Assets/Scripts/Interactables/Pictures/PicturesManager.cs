using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interactables.Pictures
{
    public class PicturesManager : MonoBehaviour
    {
        public InteractableManager InteractableManager;

        public GameObject PicturePanel;
        public List<GameObject> ImageSlots = new List<GameObject>();
        public List<GameObject> PictureImages = new List<GameObject>();

        public List<PictureSlot> PictureSlots = new List<PictureSlot>();
        public List<Picture> Pictures = new List<Picture>();
        public Text PicturesText;

        public int Counter;
        private bool isCoolingDown = false;
        private float timeStamp;
        private const int coolDownPeriodInSeconds = 4;
        public string FinalComination { get; set; }


        void Start()
        {
            Instantiate();
        }

        void Update()
        {
            CoolingDown(isCoolingDown);
            if (Counter == 2)
            {
                Counter = 0;
                string combination = "";

                for (int i = 0; i < 3; i++)
                {
                    combination += this.ImageSlots[i].transform.GetChild(0).GetComponent<PictureImage>()
                        .Picture.ID.ToString();

                }
                Debug.Log("Combination:" + combination);
                if (FinalComination.Equals(combination))
                {
                    Debug.Log("Combination Correct");

                    foreach (var imageSlot in ImageSlots)
                    {
                        imageSlot.transform.GetComponent<Image>().color = Color.green;
                    }

                    this.PicturesText.text = "Correct Order";
                    timeStamp = Time.time + coolDownPeriodInSeconds;
                    isCoolingDown = true;

                    var inv = GameObject.Find("Inventory").GetComponent<Inventory>();
                    if (!inv.items.Exists(f => f.ID == 3))
                    {
                        inv.AddItem(3);
                    }
                    
                }
                else
                {
                    foreach (var imageSlot in ImageSlots)
                    {
                        imageSlot.transform.GetComponent<Image>().color = Color.red;
                    }
                    this.PicturesText.text = "Incorrect Order";
                    timeStamp = Time.time + coolDownPeriodInSeconds;
                    isCoolingDown = true;

                }
            }

            
        }

        public void CoolingDown(bool coolDown)
        {
            if (coolDown)
            {
                if (timeStamp <= Time.time)
                {
                    foreach (var imageSlot in ImageSlots)
                    {
                        imageSlot.transform.GetComponent<Image>().color = Color.white;
                    }
                   
                       this.PicturesText.text = "Drag and Drop Pictures in the right order with only two moves";
                       isCoolingDown = false;
                    Clean();
                    Instantiate();
                }
                
            }
        }

        public void Clean()
        {
            ImageSlots = new List<GameObject>();
            PictureImages = new List<GameObject>();
            PictureSlots = new List<PictureSlot>();
            Pictures = new List<Picture>();
            Counter = 0;

        }

        public void Instantiate()
        {
            PicturePanel = GameObject.Find("PicturesPanel");
            InteractableManager = GameObject.Find("Interaction").GetComponent<InteractableManager>();
            PicturesText = GameObject.Find("PicturesText").GetComponent<Text>();

            for (int i = 0; i < 3; i++)
            {
                ImageSlots.Add(PicturePanel.transform.GetChild(i).gameObject);
                PictureImages.Add(ImageSlots[i].transform.GetChild(0).gameObject);
                PictureSlots.Add(ImageSlots[i].transform.GetComponent<PictureSlot>());
                PictureSlots[i].ID = i;
                ImageSlots[i].transform.GetChild(0).GetComponent<PictureImage>().SlotNumber = i;
                Debug.Log("Manager ID: " + ImageSlots[i].transform.GetChild(0).GetComponent<PictureImage>().SlotNumber);
                ImageSlots[i].transform.GetChild(0).GetComponent<PictureImage>().Picture =
                    new Picture() { ID = i, Name = "Picture" + i };
                Pictures.Add(new Picture() { ID = i, Name = "Picture" + (i + 1) });
                PictureImages[i].transform.GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("CanvasWallArt/Picture" + (i + 1));
                FinalComination = GameObject.Find("Pictures").GetComponent<PicturesOnTheWall>().FinalCombination;

            }
        }

    }
}
