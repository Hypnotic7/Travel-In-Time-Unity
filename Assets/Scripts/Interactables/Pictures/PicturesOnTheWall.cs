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
            InteractableManager = GameObject.Find("Interaction").GetComponent<InteractableManager>();
            InteractableManager.picturesInteraction = this.gameObject;
            if (InteractableManager == null) return;
            playerAgent = GameObject.Find("Character(Clone)").GetComponent<NavMeshAgent>();
            InteractableManager.Activate("Pictures");

        }
    }
}
