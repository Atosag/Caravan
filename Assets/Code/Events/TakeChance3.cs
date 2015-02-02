using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TakeChance3 : Events {

	protected override void InternalInit ()
	{
		
	}

	public void Ignore(){
		FeedbackUI.feedbackUI.ShowText("You ignore the couple and travel onward");
		continuePlaying();
	}

	public void Wrong(){
		caravan.stolenfrommoney(20);
		caravan.setmoney((caravan.getmoney() < 0) ? 0 : caravan.getmoney());
		FeedbackUI.feedbackUI.ShowText(string.Format("The couple raids you and steals {0} money", 20));
		continuePlaying();
	}

	public void Right(){
		caravan.addgoods(2);
		FeedbackUI.feedbackUI.ShowText(string.Format("You shamelessly raid the couple and steal {0} goods", 2));
		continuePlaying();

	}
}
