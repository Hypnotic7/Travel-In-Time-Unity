using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interactables.Craft
{
    public class Craft : Interactable
    {
        public InteractableManager interactableManager;
        public override void Interact()
        {
            interactableManager = GameObject.Find("Interaction").GetComponent<InteractableManager>();
            interactableManager.craftInteraction = this.gameObject;
            if(GameObject.Find("AlchemyTable"))
                    interactableManager.Activate("AlchemyTable");

        }

    }
}
