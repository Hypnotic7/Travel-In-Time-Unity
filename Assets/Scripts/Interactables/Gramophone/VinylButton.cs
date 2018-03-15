using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Interactables.Gramophone
{
    public class VinylButton : MonoBehaviour, IPointerClickHandler
    {
        private GramophoneInteraction gramophone;
        private int vinylClicked;

        void Start()
        {
            gramophone = GameObject.Find("Gramophone_Interaction_Panel(Clone)").GetComponent<GramophoneInteraction>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            string buttonClicked = this.gameObject.name.Substring(6);

            int.TryParse(buttonClicked, out vinylClicked);

            gramophone.SetOutputSlot(vinylClicked - 1);
        }

        
    }
}
