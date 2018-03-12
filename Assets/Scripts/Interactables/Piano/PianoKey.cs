using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Interactables.Piano
{
    public class PianoKey : MonoBehaviour, IPointerClickHandler
    {
        private PianoInteraction piano;
        private int keyClicked;


        void Start()
        {
            piano = GameObject.Find("Piano_Interaction_Panel(Clone)").GetComponent<PianoInteraction>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log(this.transform.GetChild(0).GetComponent<Text>().text);
            string numberKeyClicked = this.gameObject.name.Substring(8);

            if (numberKeyClicked.Length == 3)
            {
                int.TryParse(numberKeyClicked[0].ToString(), out keyClicked);
            }
            else if (numberKeyClicked.Length == 5)
            {
                int.TryParse(numberKeyClicked[0].ToString() + numberKeyClicked[1].ToString(), out keyClicked);
            }
            else
            {
                int.TryParse(numberKeyClicked, out keyClicked);
            }
            
            piano.DisplayOutput(keyClicked);
            
        }
    }
}
