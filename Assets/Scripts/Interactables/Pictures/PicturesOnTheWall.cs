using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Interactables.Pictures
{
    public class PicturesOnTheWall : Interactable
    {
        public InteractableManager InteractableManager;


        public string FinalCombination;
        private Color startcolor;

        void OnMouseEnter()
        {
            for (int i = 0; i < 3; i++)
            {
                startcolor = transform.GetChild(i).GetComponent<Renderer>().material.color;
                transform.GetChild(i).GetComponent<Renderer>().material.color = Color.magenta;
            }
                
           
           
        }
        void OnMouseExit()
        {
            for (int i = 0; i < 3; i++)
            {
                transform.GetChild(i).GetComponent<Renderer>().material.color = startcolor;
            }
        }
        void Start()
        {
           
        }
        public override void Interact()
        {
            var inv = GameObject.Find("Inventory").GetComponent<Inventory.Inventory>();
            if (inv != null)
            {
                Debug.Log(GameObject.Find("GameManager").GetComponent<GameManager>().currentTime);
                if (GameObject.Find("GameManager").GetComponent<GameManager>().currentTime == "Past_Time_Test")
                {
                    if(!GameplayChecker.PicturesPastPuzzleSolved)
                        InstantiateAndActivate();
                }

                else if (PlayerPrefs.GetString("CurrentTime") == "Present_Time_Test")
                {
                    if(!GameplayChecker.PicturesPresentPuzzleSolved)
                    InstantiateAndActivate();
                }
            }

        }

        public void DestroyPictures()
        {
            Destroy(this.gameObject);
        }

        private void InstantiateAndActivate()
        {
            InteractableManager = GameObject.Find("Interaction").GetComponent<InteractableManager>();
            InteractableManager.picturesInteraction = this.gameObject;
            if (InteractableManager == null) return;
            playerAgent = GameObject.Find("Character(Clone)").GetComponent<NavMeshAgent>();
            InteractableManager.Activate("Pictures");
        }
    }
}
