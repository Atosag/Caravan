using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TakeChance_two_right : TakeChance {
	[SerializeField]
	Feedback right2Feedback = null;

	public void Right2(){
		for (int i = 0; i < right2Feedback.amount; i++) {
			caravan.Guards.Add (new Strong_Guard());
		}
		FeedbackUI.feedbackUI.ShowText(string.Format(right2Feedback.feedback, right2Feedback.amount));
		continuePlaying();
	}
}