using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Interactables
{
    public class Digits : MonoBehaviour, IPointerClickHandler
    {
        private Safe safe;
        private int numberClicked;
        void Start()
        {
            safe = GameObject.Find("Safe").GetComponent<Safe>();
        }

        
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log(this.transform.GetChild(0).GetComponent<Text>().text);
            int.TryParse(this.transform.GetChild(0).GetComponent<Text>().text, out numberClicked);
            safe.DisplayPinNumbers(numberClicked);
        }
    }

}
