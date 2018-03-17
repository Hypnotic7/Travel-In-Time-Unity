using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameplayChecker : MonoBehaviour
    {
        public static bool VinylPickUpWest { get; set; }

        public static bool VinylPickUpNorthEast { get; set; }
        public static bool VinylPickUpSouth { get; set; }
        public static bool VinylPickUpEast { get; set; }
        public static bool InvisibilityMode { get; set; }
        void Start()
        {
            VinylPickUpEast = false;
            VinylPickUpNorthEast = false;
            VinylPickUpSouth = false;
            VinylPickUpWest = false;
            InvisibilityMode = false;
        }
    }
}
