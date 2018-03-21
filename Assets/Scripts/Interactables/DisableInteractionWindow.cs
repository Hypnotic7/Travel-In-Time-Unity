using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Interactables.Craft;
using Assets.Scripts.Interactables.Gramophone;
using Assets.Scripts.Interactables.Piano;
using Assets.Scripts.Interactables.Pictures;
using Interactables.Safe;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisableInteractionWindow : MonoBehaviour, IPointerClickHandler {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        var interactableManager = GameObject.Find("Interaction").GetComponent<InteractableManager>();
       
        if (GameObject.Find("Pictures_Interaction_Panel(Clone)") != null)
        {
            Destroy(GameObject.Find("Pictures_Interaction_Panel(Clone)"));
            var pictures = GameObject.Find("PicturesPanel").GetComponent<PicturesManager>();
            pictures.Clean();
            interactableManager.interactionWindow.SetActive(false);

        }

        else if (GameObject.Find("Safe_Interaction_Panel(Clone)") != null)
        {
            
                Destroy(GameObject.Find("Safe_Interaction_Panel(Clone)"));
            var safe = GameObject.Find("Safe").GetComponent<Safe>();
                safe.Clean();
                interactableManager.interactionWindow.SetActive(false);
            
           
        }
        else if (GameObject.Find("Piano_Interaction_Panel(Clone)") != null)
        {

            Destroy(GameObject.Find("Piano_Interaction_Panel(Clone)"));
            var piano = GameObject.Find("Piano").GetComponent<Piano>();
            piano.Clean();
            interactableManager.interactionWindow.SetActive(false);


        }
        else if (GameObject.Find("Craft_Interaction_Panel(Clone)") != null)
        {

            Destroy(GameObject.Find("Craft_Interaction_Panel(Clone)"));
            var craft = GameObject.Find("AlchemyTable").GetComponent<Craft>();
            //craft.Clean();
            interactableManager.interactionWindow.SetActive(false);


        }else if (GameObject.Find("Gramophone_Interaction_Panel(Clone)") != null)
        {

            Destroy(GameObject.Find("Gramophone_Interaction_Panel(Clone)"));
            var craft = GameObject.Find("Gramophone").GetComponent<Gramophone>();
            //craft.Clean();
            interactableManager.interactionWindow.SetActive(false);


        }
        else if (GameObject.Find("GramophoneRecords_Interaction_Panel(Clone)") != null)
        {

            Destroy(GameObject.Find("GramophoneRecords_Interaction_Panel(Clone)"));
            var craft = GameObject.Find("Gramophone").GetComponent<Gramophone>();
            //craft.Clean();
            interactableManager.interactionWindow.SetActive(false);


        }
        else if (GameObject.Find("Puzzle_Interaction_Panel(Clone)") != null)
        {
            Destroy(GameObject.Find("Puzzle_Interaction_Panel(Clone)"));
            interactableManager.interactionWindow.SetActive(false);
        }
    }

    public void DisablePictures()
    {
        var interactableManager = GameObject.Find("Interaction").GetComponent<InteractableManager>();
        Destroy(GameObject.Find("Pictures_Interaction_Panel(Clone)"));
        var pictures = GameObject.Find("PicturesPanel").GetComponent<PicturesManager>();
        pictures.Clean();
        interactableManager.interactionWindow.SetActive(false);
    }
}
