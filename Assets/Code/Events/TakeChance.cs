using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TakeChance : Events {
	[SerializeField]
	Feedback ignoreFeedback = null, rightFeedback = null, wrongFeedback = null;

	protected override void InternalInit ()
	{
	}
	
	public void Ignore(){
		FeedbackUI.feedbackUI.ShowText(ignoreFeedback.feedback);
		continuePlaying();
    }

	public void Right(){
		if(rightFeedback.moneyOrGoods == Feedback.MoneyOrGoods.Money)
			caravan.addmoney(rightFeedback.amount);
		else if(rightFeedback.moneyOrGoods == Feedback.MoneyOrGoods.Goods)
			caravan.addgoods(rightFeedback.amount);
		FeedbackUI.feedbackUI.ShowText(string.Format(rightFeedback.feedback, rightFeedback.amount));
		continuePlaying();
	}

	public void Wrong(){
		int amountLost = 0;
		if(wrongFeedback.moneyOrGoods == Feedback.MoneyOrGoods.Money) {
			amountLost = (caravan.getmoney() < wrongFeedback.amount) ? caravan.getmoney() : wrongFeedback.amount;
			caravan.stolenfrommoney(amountLost);
		}
		else if(wrongFeedback.moneyOrGoods == Feedback.MoneyOrGoods.Goods) {
			amountLost = (caravan.getgoods() < wrongFeedback.amount) ? caravan.getgoods() : wrongFeedback.amount;
			caravan.stolenfrom(amountLost);
		}

		FeedbackUI.feedbackUI.ShowText(string.Format(wrongFeedback.feedback, amountLost));
		continuePlaying();
	}

	[System.Serializable]
	protected class Feedback {
		public enum MoneyOrGoods {
			Money, Goods
		}
		public MoneyOrGoods moneyOrGoods = MoneyOrGoods.Money;
		public int amount = 0;
		public string feedback = "";
	}
}