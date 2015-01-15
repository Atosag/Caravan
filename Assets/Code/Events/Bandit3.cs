using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bandit3 : Bandit {
	protected override void InternalInit ()
	{
		sound.Play ();
		bandits.Add(new Strong_Enemy());
	}
}
