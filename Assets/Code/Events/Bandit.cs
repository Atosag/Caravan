using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bandit : Events
{
	[SerializeField]
	protected AudioSource
		sound = null;
	[SerializeField]
	protected List<Enemy>
		bandits = new List<Enemy> ();
	[SerializeField]
	int weakEnemies = 0, strongEnemies = 0;

	protected override void InternalInit ()
	{
		//sound.Play ();
		for(int i = 0; i < weakEnemies; i++){
			bandits.Add(new Weak_Enemy());
		}
		for(int i = 0; i < strongEnemies; i++){
			bandits.Add(new Strong_Enemy());
		}
	}

	public void flee ()
	{
		internalFlee (0, 0);
	}

	private void internalFlee (int weakGuardsLost, int strongGuardsLost)
	{
		int potatis = 0;
		
		foreach (var enemy in bandits) {
			caravan.stolenfrom (enemy.goodstaken);
			potatis += enemy.goodstaken;
		}
		//Lose the game if BELOW zero, you can survive on zero
		if (caravan.getgoods () < 0) {
			caravan.setgoods (0);
			losegame ();
		}
		string additionalInfo = string.Empty;
		if (weakGuardsLost > 0) 
			additionalInfo += string.Format (", {0} weak guards", weakGuardsLost);
		if (strongGuardsLost > 0)
			additionalInfo += string.Format (" and {0} strong guards", strongGuardsLost);
		FeedbackUI.feedbackUI.ShowText (string.Format ("You just lost: {0} goods{1}", potatis, additionalInfo));
		continuePlaying ();
	}
	
	public void fight ()
	{

		bandits.Shuffle ();
		caravan.Guards.Shuffle ();

		int sGuards = caravan.getStrongGuards ();
		int wGuards = caravan.getWeakGuards ();

		while (bandits.Count > 0 && caravan.Guards.Count > 0) {
			unitFight (bandits [0], caravan.Guards [0]);
			if (bandits [0].defence <= 0)
				bandits.RemoveAt (0);
			if (caravan.Guards [0].defence <= 0)
				caravan.Guards.RemoveAt (0);
		}

		int weakGuardsLost = wGuards - caravan.getWeakGuards (),
		strongGuardsLost = sGuards - caravan.getStrongGuards ();
		if (bandits.Count > 0 && caravan.Guards.Count <= 0) {
			internalFlee (weakGuardsLost, strongGuardsLost);
		} else {
			string additionalInfo = "You just lost:\n";
			if (weakGuardsLost > 0) 
				additionalInfo += string.Format ("{0} weak guards\n", weakGuardsLost);
			if (strongGuardsLost > 0)
				additionalInfo += string.Format ("{0} strong guards\n", strongGuardsLost);
			FeedbackUI.feedbackUI.ShowText (additionalInfo);
		}
		continuePlaying ();
	}

	private void unitFight (Enemy enm, Guard gurd)
	{
		gurd.defence -= enm.attack;
		enm.defence -= gurd.attack;
	}
}
