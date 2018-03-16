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
        private List<Color> startcolor;

        void Start()
        {
            startcolor = new List<Color>();
        }

        void OnMouseEnter()
        {
            for (int i = 0; i < transform.GetChild(0).childCount; i++)
            {
                startcolor.Add(this.transform.GetChild(0).transform.GetChild(i).GetComponent<Renderer>().material.color);
                this.transform.GetChild(0).transform.GetChild(i).GetComponent<Renderer>().material.color = Color.magenta;
            }
            

        }
        void OnMouseExit()
        {
            for (int i = 0; i < transform.GetChild(0).childCount; i++)
            {
                this.transform.GetChild(0).transform.GetChild(i).GetComponent<Renderer>().material.color = startcolor[i];
            }
           
        }

        public override void Interact()
        {
            interactableManager = GameObject.Find("Interaction").GetComponent<InteractableManager>();
            interactableManager.gramophoneInteraction = this.gameObject;
            if(GameObject.Find("Gramophone"))
                interactableManager.Activate("Gramophone");
        }
    }
}
