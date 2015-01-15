using UnityEngine;

[System.Serializable]
public class Weak_Enemy : Enemy
{
	public Weak_Enemy ()
	{
		attack = 1;
		defence = 1;
		goodstaken = Random.Range(0, 2);
	}
}

