using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interactables
{
    public class Safe : Interactable
    {
        public GameObject SafePinNumberObj;
        public InteractableManager InteractableManager;
        public SafePinNumber SafePinNumber;
        public List<Transform> PinNumbersObjects;
        public bool IsSafeOpen = false;
        public Transform SafeDoors;


        void Start()
        {
            PinNumbersObjects = new List<Transform>();
            this.SafePinNumber = new SafePinNumber();
            SafeDoors = GameObject.Find("Safe").transform.GetChild(0).GetComponent<Transform>();
        }

        public override void Interact()
        {
            if (!IsSafeOpen)
            {
                InteractableManager = GameObject.Find("Interaction").GetComponent<InteractableManager>();
                InteractableManager.Activate("Safe");
                SafePinNumberObj = GameObject.Find("Code");
                if (PinNumbersObjects.Count > 1)
                {
                    PinNumbersObjects = new List<Transform>();
                }

                for (int i = 0; i < 4; i++)
                {
                    PinNumbersObjects.Add(SafePinNumberObj.transform.GetChild(i));
                }
            }
            else
            {
                SafeDoors.Rotate(new Vector3(0f, 0f, 99.192f));
                IsSafeOpen = false;
            }
           

        }

        public void DisplayPinNumbers(int number)
        {
            foreach (var pinNumbersObject in PinNumbersObjects)
            {
                var pinNumberText = pinNumbersObject.transform.GetChild(0).GetComponent<Text>();
                if (pinNumberText.text.Equals(string.Empty))
                {
                    pinNumberText.text = number.ToString();
                    if (SafePinNumber.UpdatePinNumber(number))
                    {
                        foreach (var pinNumberObject in PinNumbersObjects)
                        {
                            pinNumberObject.transform.GetComponent<Image>().color = Color.green;
                           

                        }
                        var doors = GameObject.Find("Safe").transform.GetChild(0).GetComponent<Transform>();
                        doors.Rotate(new Vector3(0f, 0f, -99.192f));
                        IsSafeOpen = true;
                        //var locker = doors.GetChild(0).GetComponent<Transform>();
                        //locker.eulerAngles = new Vector3(0f, 0f, -90f);
                        Debug.Log("Correct Pin");
                       
                    }
                    
                    break;
                }
            }
        }

        public void Clean()
        {
            for (int i = 0; i < PinNumbersObjects.Count; i++)
            {
                PinNumbersObjects[i].transform.GetComponent<Image>().color = Color.white;

                this.SafePinNumber.PinNumbers[i] = 0;
            }
           
           
        }
        
    }
}
