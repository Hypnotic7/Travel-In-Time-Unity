using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Interactables.Gramophone
{
    public class UnlockPuzzle : MonoBehaviour, IPointerClickHandler
    {
        public GameObject RequirementObject;
        public int RequirementID;
        public int Amount;

        void Start()
        {
            PlayerPrefs.SetInt("UnlockedGramophonePuzzle", 0);
        }

        public bool CheckForRequirements()
        {
            if (RequirementObject == null) return false;

            var counter = 0;
            if (RequirementObject.transform.GetChild(1) != null)
            {
                var requirementText = RequirementObject.transform.GetChild(1).GetComponent<Text>().text.Substring(0,5);
                var contains = CheckInventory(requirementText);
                if (!contains) return false;
                contains = CheckForAmount(Amount);
                if (!contains) return false;
                removeItemsThatWasNeeded();
                deactivateAndActivate("Gramophone");
                reward(10);
            }
            return true;

        }

        private void reward(int itemID)
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().AddItem(itemID);
        }

        private void deactivateAndActivate(string interaction)
        {
            PlayerPrefs.SetInt("UnlockedGramophonePuzzle", 1);
            GameObject.Find("Interaction").GetComponent<InteractableManager>().Activate(interaction);
            Destroy(GameObject.Find("GramophoneRecords_Interaction_Panel(Clone)"));
        }

        private void removeItemsThatWasNeeded()
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().RemoveItem(RequirementID);
        }

        private bool CheckForAmount(int amount)
        {
            var inv = GameObject.Find("Inventory").GetComponent<Inventory>();

            for (int i = 0; i < inv.items.Count; i++)
            {
                if (inv.items[i].ID == RequirementID)
                {
                    ItemData data = inv.slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    if (data.amount == amount) break;
                    return false;
                }
            }
            return true;

        }

        private bool CheckInventory(string requirementText)
        {

            return GameObject.Find("Inventory").GetComponent<Inventory>().items.Exists(f => f.Title == requirementText);    
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            CheckForRequirements();
           

        }
    }
}
