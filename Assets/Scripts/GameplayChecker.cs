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
        public static bool PicturesPastPuzzleSolved { get; set; }
        public static bool PicturesPresentPuzzleSolved { get; set; }
        public static bool SafePuzzleSolved { get; set; }
        public static bool PianoPuzzleSolved { get; set; }
        public static bool CraftedInvisiblityFlask { get; set; }
        public static bool GramophonePuzzle { get; set; }
        public static bool EmptyFlaskPickedUp { get; set; }
        public static bool AreDoorsOpen { get; set; }
        public static bool FirstTimeOpened { get; set; }
        void Start()
        {
            VinylPickUpEast = false;
            VinylPickUpNorthEast = false;
            VinylPickUpSouth = false;
            VinylPickUpWest = false;
            InvisibilityMode = false;
            PicturesPastPuzzleSolved = false;
            PicturesPresentPuzzleSolved = false;
            SafePuzzleSolved = false;
            PianoPuzzleSolved = false;
            CraftedInvisiblityFlask = false;
            GramophonePuzzle = false;
            EmptyFlaskPickedUp = false;
            AreDoorsOpen = false;
            FirstTimeOpened = false;
        }

    }
}
