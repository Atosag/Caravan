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
		FeedbackUI.feedbackUI.ShowText("You ignore the strange structure and travel onward");
		continuePlaying();
	}

	public void Wrong(){
		caravan.stolenfrommoney(10);
		caravan.setmoney((caravan.getmoney() < 0) ? 0 : caravan.getmoney());
		FeedbackUI.feedbackUI.ShowText(string.Format("You panick away accidentally drop {0} money", 10));
		continuePlaying();
	}

	public void Right(){
		caravan.addmoney(25);
		FeedbackUI.feedbackUI.ShowText(string.Format("The touch fades the structure away, leaving {0} money", 25));
		continuePlaying();

	}
}
