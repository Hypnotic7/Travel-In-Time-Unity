using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour {

    public string Title { get; set; }
    public string Description { get; set; }
    public string FinalResult { get; set; }

    public GameObject interactionWindow { get; set; }
    public GameObject interactionPanel { get; set; }
    public List<GameObject> interactionWindows = new List<GameObject>(4);
    public GameObject safeInteraction;
    public GameObject picturesInteraction;
    public GameObject pianoInteraction;
    public GameObject craftInteraction;

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
        if (interactionWindow != null) interactionWindow.SetActive(true);

        if (interactableString == "Safe" && !safeInteraction.Equals(null))
        {
            if (!GameObject.Find("Safe_Interaction_Panel(Clone)"))
            {
                safeInteraction = Instantiate(interactionWindows[0]);
                safeInteraction.transform.SetParent(interactionWindow.transform, false);

            }
        }
        else if (interactableString == "Pictures" && !picturesInteraction.Equals(null))
        {
            if (!GameObject.Find("Pictures_Interaction_Panel(Clone)"))
            {
                picturesInteraction = Instantiate(interactionWindows[1]);
                picturesInteraction.transform.SetParent(interactionWindow.transform, false);
            }
        }
        else if (interactableString == "Piano" && !pianoInteraction.Equals(null))
        {
            if (!GameObject.Find("Piano_Interaction_Panel(Clone)"))
            {
                pianoInteraction = Instantiate(interactionWindows[2]);
                pianoInteraction.transform.SetParent(interactionWindow.transform,false);
            }
            
        }
        else if (interactableString == "AlchemyTable" && !craftInteraction.Equals(null))
        {
            craftInteraction = Instantiate(interactionWindows[3]);
            craftInteraction.transform.SetParent(interactionWindow.transform,false);
        }

    }

   

    

    
}
