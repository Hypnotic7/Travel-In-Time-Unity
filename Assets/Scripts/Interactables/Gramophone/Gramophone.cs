using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interactables.Gramophone
{
    public class Gramophone : Interactable
    {
        public InteractableManager interactableManager;

        public override void Interact()
        {
            interactableManager = GameObject.Find("Interaction").GetComponent<InteractableManager>();
            interactableManager.gramophoneInteraction = this.gameObject;
            if(GameObject.Find("Gramophone"))
                interactableManager.Activate("Gramophone");
        }
    }
}
