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
		caravan.stolenfrommoney(1);
		FeedbackUI.feedbackUI.ShowText("You were wrong, you lost one money.");
		continuePlaying();
	}

	public void Right(){
		caravan.addmoney(5);
		FeedbackUI.feedbackUI.ShowText(string.Format("You won {0} money", 5));
		continuePlaying();
	}
}
