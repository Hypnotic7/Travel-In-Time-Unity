using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interactables.Safe
{
    public class Safe : Interactable
    {
        public GameObject SafePinNumberObj;
        public InteractableManager InteractableManager;
        public SafePinNumber SafePinNumber;
        public List<Transform> PinNumbersObjects;
        public bool IsSafeOpen = false;
        public Transform SafeDoors;
        public Text SafeText;
        private float timeStamp;
        private bool IsCoolingDown = false;
        private const int coolDownPeriodInSeconds = 4;




        void Start()
        {
            PinNumbersObjects = new List<Transform>();
            this.SafePinNumber = new SafePinNumber();
            SafeDoors = GameObject.Find("Safe").transform.GetChild(0).GetComponent<Transform>();
            SafeText = GameObject.Find("SafeText").transform.GetComponent<Text>();
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
                    var safeText = GameObject.Find("SafeText").gameObject.GetComponent<Text>();
                    pinNumberText.text = number.ToString();
                    if (SafePinNumber.UpdatePinNumber(number))
                    {
                        foreach (var pinNumberObject in PinNumbersObjects)
                        {
                            pinNumberObject.transform.GetComponent<Image>().color = Color.green;
                        }
                        var doors = GameObject.Find("Safe").transform.GetChild(0).GetComponent<Transform>();
                        doors.Rotate(new Vector3(0f, 0f, -99.192f));
                        timeStamp = Time.time + coolDownPeriodInSeconds;
                        IsSafeOpen = true;
                        safeText.text = "Correct Pin Number";
                        
                        var inv = GameObject.Find("Inventory").GetComponent<Inventory>();
                        if (!inv.items.Exists(f => f.ID == 2))
                        {
                            inv.AddItem(2);
                        }
                        Debug.Log("Correct Pin");

                    }
                    else if (SafePinNumber.LengthOfCurrentString() == 4)
                    {
                        if (!SafePinNumber.SafeCode.Contains("0"))
                        {
                            foreach (var pinNumberObject in PinNumbersObjects)
                            {
                                pinNumberObject.transform.GetComponent<Image>().color = Color.red;
                            }
                           
                            
                            timeStamp = Time.time + coolDownPeriodInSeconds;
                            IsCoolingDown = true;

                            safeText.text = "Incorrect Pin Number";
                        }
                        
                    }
                    
                    break;
                }
            }
        }

        void Update()
        {
            if (IsCoolingDown)
            {
                if (timeStamp <= Time.time)
                {
                    foreach (var pinNumberObject in PinNumbersObjects)
                    {
                        pinNumberObject.transform.GetChild(0).GetComponent<Text>().text = string.Empty;
                    }
                    var safeText = GameObject.Find("SafeText").gameObject.GetComponent<Text>();
                    safeText.text = "Decode safe with 4 different Numbers";
                    Clean();
                    IsCoolingDown = false;
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

        public void CoolingDown()
        {
            
        }
        
    }
}
