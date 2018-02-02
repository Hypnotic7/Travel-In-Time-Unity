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
