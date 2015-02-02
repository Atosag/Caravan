using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Town : Events
{
	protected override void InternalInit ()
	{
		caravan.addmoney (caravan.getgoodsvalue ());
		caravan.setgoods (0);
		GameUI.gameUI.UpdateStats();
	}

	public void BuyGoods ()
	{
		if (caravan.getmoney () >= 5 && caravan.getgoods () < 20) {
			caravan.stolenfrommoney (5);
			caravan.addgoods (1);
			GameUI.gameUI.UpdateStats();
		}
	}

	public void BuyWGuards ()
	{
		if (caravan.getmoney () >= 5) {
			caravan.stolenfrommoney (5);
			caravan.Guards.Add (new Weak_Guard ());
			GameUI.gameUI.UpdateStats();
		}
	}

	public void BuySGuards ()
	{
		if (caravan.getmoney () >= 9) {
			caravan.stolenfrommoney (9);
			caravan.Guards.Add (new Strong_Guard ());
			GameUI.gameUI.UpdateStats();
		}
	}

	public void TravelOnward ()
	{
		continuePlaying ();
	}
}
