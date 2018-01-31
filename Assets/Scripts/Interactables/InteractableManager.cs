using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour {

    public string Title { get; set; }
    public string Description { get; set; }
    public string FinalResult { get; set; }

    public GameObject interactionWindow { get; set; }
    public GameObject interactionPanel { get; set; }
    public List<GameObject> interactionWindows = new List<GameObject>(3);
    public GameObject safeInteraction;
    public GameObject picturesInteraction;

	// Use this for initialization
	void Start ()
	{
	    interactionWindow = GameObject.Find("Interaction_Window_Panel");
	    interactionWindow.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Activate(string interactableString)
    {
        if (interactableString == "Safe" && safeInteraction.Equals(null))
        {
                safeInteraction = Instantiate(interactionWindows[0]);
                safeInteraction.transform.SetParent(interactionWindow.transform, false);
        }
        else if (interactableString == "Pictures" && picturesInteraction.Equals(null))
        {
            picturesInteraction = Instantiate(interactionWindows[1]);
            picturesInteraction.transform.SetParent(interactionWindow.transform, false);
        }

        interactionWindow.SetActive(true);

    }

   

    

    
}
