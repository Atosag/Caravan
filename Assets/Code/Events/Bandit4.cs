using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bandit4 : Bandit
{
	protected override void InternalInit ()
	{
		sound.Play ();
		bandits.Add (new Strong_Enemy ());
		bandits.Add (new Strong_Enemy ());
	}
}
