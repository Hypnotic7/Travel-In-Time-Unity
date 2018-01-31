using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interactables.Pictures
{
    public class PicturesOnTheWall : Interactable
    {
        public InteractableManager InteractableManager;
        void Start()
        {
            InteractableManager = GameObject.Find("Interaction").GetComponent<InteractableManager>();
        }
        public override void Interact()
        {
            InteractableManager.Activate("Pictures");
        }
    }
}
