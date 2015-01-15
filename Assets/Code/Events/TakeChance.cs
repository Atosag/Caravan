using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TakeChance : Events {

	protected override void InternalInit ()
	{
		
	}
	
	public void Ignore(){
		continuePlaying();
    }

	public void Wrong(){

		caravan.stolenfrommoney(20);
		caravan.setmoney((caravan.getmoney() < 0) ? 0 : caravan.getmoney());
		continuePlaying();
	}

	public void Right(){

		caravan.addmoney(10);
		continuePlaying();

	}
}
