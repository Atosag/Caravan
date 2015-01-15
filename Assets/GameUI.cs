using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

	[SerializeField]
	Caravan
		caravan;
	[SerializeField]
	Text
		textObject;

	// Update is called once per frame
	void Update ()
	{
		textObject.text = "Goods: " + caravan.getgoods () + "\n" +
			"Strong Guards: " + caravan.getStrongGuards() + "\n" +
			"Weak Guards: " + caravan.getWeakGuards() + "\n" +
			"Money: " + caravan.getmoney();
	}
}
