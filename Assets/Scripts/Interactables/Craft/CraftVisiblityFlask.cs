using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Interactables.Craft
{
    public class CraftVisiblityFlask : MonoBehaviour, ICraft<GameObject>,IPointerClickHandler
    {
        public GameObject[] gameObjects = new GameObject[2];
        public int rewardID;
        public int[] ingrediantsID;

        public bool CheckForIngrediants()
        {
           
            if (gameObjects == null) return false;

            var counter = 0;
            var gameObjectsText = new string[gameObjects.Length];
            var contains = new bool[gameObjects.Length];
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjectsText[i] = gameObjects[i].transform.GetChild(1).transform.GetComponent<Text>().text;
                contains[i] = checkInventory(gameObjectsText[i]);
                if (contains[i]) counter++;
            }

            if (counter == gameObjects.Length) Reward();

            return false;
        }

        private bool checkInventory(string gameObjectsText)
        {
            return GameObject.Find("Inventory").GetComponent<Inventory>().items.Exists(f=>f.Title == gameObjectsText);
            
        }

        private void removeItemsThatWasNeeded()
        {
            for (int i = 0; i < ingrediantsID.Length; i++)
            {
                GameObject.Find("Inventory").GetComponent<Inventory>().RemoveItem(ingrediantsID[i]);
            }
        }

        public void Reward()
        {
            removeItemsThatWasNeeded();
            GameObject.Find("Inventory").GetComponent<Inventory>().AddItem(rewardID);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            CheckForIngrediants();
        }
    }
}
