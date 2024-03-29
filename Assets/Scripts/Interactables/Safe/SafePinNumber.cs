﻿using UnityEngine;

namespace Interactables.Safe
{
    public class SafePinNumber : MonoBehaviour
    {

        public int[] PinNumbers { get; set; }
        public const string PinNumber = "1469";
        public string SafeCode;


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
            SafeCode = pinNumbersString;

            if (SafeCode.Equals(PinNumber))
            {
                for (int i = 0; i < PinNumbers.Length; i++)
                {
                    PinNumbers[i] = 0;
                    SafeCode = "";
                }
                return true;
            }

            return false;
        }

        public int LengthOfCurrentString()
        {
            return SafeCode.Length;
        }
    }

}

