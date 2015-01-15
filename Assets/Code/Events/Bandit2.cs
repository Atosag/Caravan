using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bandit2 : Bandit {
	protected override void InternalInit ()
	{
		sound.Play ();
		bandits.Add(new Weak_Enemy());
		bandits.Add(new Weak_Enemy());
		bandits.Add(new Weak_Enemy());
		bandits.Add(new Weak_Enemy());
	}
}
