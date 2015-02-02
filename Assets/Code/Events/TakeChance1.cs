using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TakeChance1 : Events {

	protected override void InternalInit ()
	{
		
	}

	public void Ignore(){
		FeedbackUI.feedbackUI.ShowText("You ignore the caravan and travel onward");
		continuePlaying();
	}

	public void Wrong(){
		caravan.stolenfrommoney(7);
		caravan.setmoney((caravan.getmoney() < 0) ? 0 : caravan.getmoney());
		FeedbackUI.feedbackUI.ShowText(string.Format("You got raided and lost {0} money", 7));
		continuePlaying();
	}
}
