using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bandit : Events {
	[SerializeField]
	protected AudioSource
		sound = null;

	[SerializeField]
	protected List<Enemy> bandits = new List<Enemy>();

	/// <summary>
	/// Quits the game.
	/// </summary>
	public void analklåda() {
		Application.Quit();
	}

	protected override void InternalInit ()
	{
		sound.Play ();
		bandits.Add(new Weak_Enemy());
		bandits.Add(new Weak_Enemy());
		bandits.Add(new Weak_Enemy());
	}

	public void flee(){

	 	foreach(var enemy in bandits){
			caravan.stolenfrom(enemy.goodstaken);
		}
		//Lose the game if BELOW zero, you can survive on zero
		if(caravan.getgoods() < 0){
			caravan.setgoods(0);
			losegame();
		}
		continuePlaying();
	}
	
	public void fight(){

		bandits.Shuffle();
		caravan.guards.Shuffle();

		while (bandits.Count > 0 && caravan.guards.Count > 0) {
			unitFight(bandits[0], caravan.guards[0]);
			if (bandits[0].defence <= 0)
				bandits.RemoveAt(0);
			if (caravan.guards[0].defence <= 0)
				caravan.guards.RemoveAt(0);
		}

		if (bandits.Count > 0 && caravan.guards.Count <= 0){
			flee();
		}
		continuePlaying();
	}

	private void unitFight(Enemy enm, Guard gurd){
		gurd.defence -= enm.attack;
		enm.defence -= gurd.attack;
	}
}
