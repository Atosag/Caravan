using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TakeChance3 : Events {

	protected override void InternalInit ()
	{
		
	}

	public void Ignore(){
		continuePlaying();
	}

	public void Wrong(){

		caravan.stolenfrommoney(30);
		caravan.setmoney((caravan.getmoney() < 0) ? 0 : caravan.getmoney());
		continuePlaying();
	}

	public void Right(){

		caravan.addgoods(5);
		continuePlaying();

	}
}
