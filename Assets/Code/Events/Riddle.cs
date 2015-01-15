using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Riddle : Events {
	[SerializeField]
	AudioSource sound = null;

	protected override void InternalInit ()
	{
		if (sound != null)
			sound.Play ();
	}

	public void Wrong(){

		continuePlaying();
	}

	public void Right(){

		caravan.addmoney(5);
		continuePlaying();

	}
}
