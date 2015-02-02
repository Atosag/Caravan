using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
	public static GameUI gameUI;
	private int
		Goods,
		Money,
		Guard_Weak,
		Guard_Strong;
	

	[SerializeField]
	Caravan
		caravan = null;
	[SerializeField]
	Text
		text_Money = null,
		text_Goods = null,
		text_WGuard = null,
		text_SGuard = null;

	void Start ()
	{
		gameUI = this;
		UpdateStats();
	}

	public void UpdateStats ()
	{
		if (caravan.getgoods () > Goods)
			text_Goods.GetComponent<Animator> ().SetTrigger ("Gained");
		else if(caravan.getgoods() < Goods)
			text_Goods.GetComponent<Animator> ().SetTrigger ("Lost");
		Goods = caravan.getgoods();
		text_Goods.text = string.Format("Goods: {0}", Goods);

		if(caravan.getmoney() > Money)
			text_Money.GetComponent<Animator> ().SetTrigger ("Gained");
		else if(caravan.getmoney() < Money)
			text_Money.GetComponent<Animator> ().SetTrigger ("Lost");
		Money = caravan.getmoney();
		text_Money.text = string.Format("Money: {0}", Money);

		if(caravan.getWeakGuards() > Guard_Weak)
			text_WGuard.GetComponent<Animator> ().SetTrigger ("Gained");
		else if(caravan.getWeakGuards() < Guard_Weak)
			text_WGuard.GetComponent<Animator> ().SetTrigger ("Lost");
		Guard_Weak = caravan.getWeakGuards();
		text_WGuard.text = string.Format("Weak guards: {0}", Guard_Weak);

		if(caravan.getStrongGuards() > Guard_Strong)
			text_SGuard.GetComponent<Animator> ().SetTrigger ("Gained");
		else if(caravan.getStrongGuards() < Guard_Strong)
			text_SGuard.GetComponent<Animator> ().SetTrigger ("Lost");
		Guard_Strong = caravan.getStrongGuards();
		text_SGuard.text = string.Format("Strong guards: {0}", Guard_Strong);
	}
}
