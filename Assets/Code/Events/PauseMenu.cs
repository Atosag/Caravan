using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : Events {

	protected override void InternalInit ()
	{
		GetComponent<AudioSource> ().Play ();
	}

	public void TravelOnward(){
		continuePlaying();
	}

	public void Quit(){
		Application.Quit ();
	}
}
