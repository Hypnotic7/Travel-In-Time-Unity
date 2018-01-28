using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Interactables;
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
        interactableManager.interactionWindow.SetActive(false);
        var safe = GameObject.Find("Safe").GetComponent<Safe>();
        safe.Clean();
        Destroy(interactableManager.safeInteraction);
       
    }
}
