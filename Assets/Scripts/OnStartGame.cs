using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartGame : MonoBehaviour
{

    public GameObject GUI;
	// Use this for initialization
	void Start ()
	{
	    if (GameObject.Find("GUI(Clone)") == null)
	    {
	        Instantiate(GUI);
	    }
	    
	}

    private void OnDestroy()
    {
        DontDestroyOnLoad(GameObject.Find("GUI"));
    }

    // Update is called once per frame
	void Update () {
		
	}
}
