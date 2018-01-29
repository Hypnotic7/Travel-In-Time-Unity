using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    public static CharacterManager control;

	// Use this for initialization
	void Awake () {
	    //if (control == null)
	    //{
	    //    DontDestroyOnLoad(this.gameObject);
	    //    control = this;
	    //}else if (control != this)
	    //{
	    //    Destroy(gameObject);
	    //}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
