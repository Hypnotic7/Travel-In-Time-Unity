using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pictures : Interactable
{
    public InteractableManager InteractableManager;
    public override void Interact()
    {
        InteractableManager = GameObject.Find("Interaction").GetComponent<InteractableManager>();
        InteractableManager.Activate("Pictures");

    }
}
