using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Assets.Scripts.Interactables.Gramophone
{
    public class GramophoneInteraction : MonoBehaviour, IGramophone
    {
        public List<Sprite> sprites;
        public List<GameObject> vinylButtons;
        public List<GameObject> outputSlots;
        public Text GramophoneText;
        private int[] input = new int[4];
        public const string Answer = "3241";
        private float timeStamp;
        private bool IsCoolingDown;
        private const int coolDownPeriodInSeconds = 3;

        void Start()
        {
            
        }

        public void SetOutputSlot(int vinylClicked)
        {
            for (int i = 0; i < outputSlots.Count; i++)
            {
                var currentSprite = outputSlots[i].transform.GetChild(0).GetComponent<Image>().sprite;
                if (currentSprite == null)
                {
                    outputSlots[i].transform.GetChild(0).gameObject.SetActive(true);
                    outputSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = sprites[vinylClicked];
                    input[i] = vinylClicked + 1;
                    if (i == outputSlots.Count - 1)
                    {
                        if (CheckIfSolved())
                        {
                            outputSlots.ForEach(f => f.GetComponent<Image>().color = Color.green);
                            GameplayChecker.GramophonePuzzle = true;
                            GramophoneText.text =
                                "You have successfully played records. The window will close in 3 seconds.";
                            reward(10);
                        }
                        else
                        {
                            GramophoneText.text =
                                "Unfortunately, the records that you have played are incorrect. The puzzle will restart in 3 seconds.";
                            outputSlots.ForEach(f => f.GetComponent<Image>().color = Color.red);
                        }
                        timeStamp = Time.time + coolDownPeriodInSeconds;
                        IsCoolingDown = true;
                    }
                    return;
                }
            }


        }
        private void reward(int itemID)
        {
            GameObject.Find("Inventory").GetComponent<Inventory.Inventory>().AddItem(itemID);
        }

        private void Clean()
        {
            for (int i = 0; i < outputSlots.Count; i++)
            {
                outputSlots[i].transform.GetChild(0).gameObject.SetActive(false);
                outputSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = new Sprite();
                input[i] = 0;
            }
        }

        void Update()
        {
            if (IsCoolingDown)
            {
                if (timeStamp <= Time.time)
                {

                    if (GameplayChecker.GramophonePuzzle)
                    {
                        Clean();
                        Destroy(gameObject);
                        GameObject.Find("Interaction").GetComponent<InteractableManager>().interactionWindow.SetActive(false);
                        IsCoolingDown = false;
                    }
                    else
                    {
                        Clean();
                        IsCoolingDown = false;
                        outputSlots.ForEach(f => f.GetComponent<Image>().color = Color.white);
                        GramophoneText.text =
                            "Play the records in the correct order to the notes that you can find on the wall by the gramophone.";
                    }
                    
                }
            }
        }


        private bool CheckIfSolved()
        {
            var inputAnswer = string.Join("", input);
            Debug.Log(inputAnswer);
            return inputAnswer.Equals(Answer);
        }
    
}
}
