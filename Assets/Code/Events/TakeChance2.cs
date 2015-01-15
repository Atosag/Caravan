using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TakeChance2 : Events {
	[SerializeField]
	AudioSource sound = null;

	protected override void InternalInit ()
	{
		sound.Play ();
	}

	public void Ignore(){
		continuePlaying();
	}

	public void Wrong(){

		caravan.stolenfrommoney(10);
		caravan.setmoney((caravan.getmoney() < 0) ? 0 : caravan.getmoney());
		continuePlaying();
	}

	public void Right(){

		caravan.addmoney(25);
		continuePlaying();

	}
}
