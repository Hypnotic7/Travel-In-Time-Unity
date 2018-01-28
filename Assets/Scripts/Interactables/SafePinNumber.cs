using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Interactables
{
    public class SafePinNumber : MonoBehaviour
    {

        public int[] PinNumbers { get; set; }
        public const string PinNumber = "1468";


        public SafePinNumber()
        {
            PinNumbers = new int[4];
        }

        public bool UpdatePinNumber(int number)
        {
            for (int i = 0; i < PinNumbers.Length; i++)
            {
                if (PinNumbers[i] != null)
                {
                    if (PinNumbers[i] == 0)
                    {
                        PinNumbers[i] = number;
                        Debug.Log(PinNumbers[i]);
                        break;
                    }
                    
                }
            }
            return CheckIsSafePinNumberCorrect();

        }

        public bool CheckIsSafePinNumberCorrect()
        {
            string pinNumbersString = "";

            for (int i = 0; i < PinNumbers.Length; i++)
            {
                pinNumbersString += PinNumbers[i];
            }

            if (pinNumbersString.Equals(PinNumber))
            {
                return true;
            }

            return false;
        }
    }

}

