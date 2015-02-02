using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Caravan : MonoBehaviour
{
	[SerializeField]
	private List<Guard>
		guards = new List<Guard> ();
	[SerializeField]
	int
		goodsSpace = 20;
	[SerializeField]
	int
		goods = 5;
	[SerializeField]
	int
		money = 25;
	[SerializeField]
	GameObject
		spear_Placeholder = null, spearBase = null;
	[SerializeField]
	List<GameObject>
		spears = new List<GameObject> ();

	public List<Guard> Guards { 
		get {
			UpdateSpears ();
			return guards;
		} 
	}

	private void UpdateSpears ()
	{
		//Clear the spears that's no longer there
		while (spears.Count > guards.Count) {
			GameObject spearToDestroy = spears [spears.Count - 1];
			spears.Remove (spearToDestroy);
			Destroy (spearToDestroy);
		}
		while (spears.Count < guards.Count && spears.Count < 5) {
			//Position-X range from -0.5 to 0.5
			//Position-Y range from -0.1 to 0.1
			//Rotation-Z range from -18 to 18
			var pos = new Vector3 ((float)(-0.5 + 0.5 * spears.Count), 
			                      (float)(-0.1 + 0.1 * spears.Count),
			                      0);
			var rot = Quaternion.Euler (0, 0, 18 - 18 * spears.Count);

			GameObject spear = (GameObject)Instantiate (spearBase);
			spear.transform.parent = spear_Placeholder.transform;
			spear.transform.localPosition = pos;
			spear.transform.localRotation = rot;
			spear.transform.localScale = new Vector3 (3, 3, 3);
			spears.Add (spear);
		}
	}

	public int getStrongGuards ()
	{
		int i = 0;
		foreach (Guard guard in Guards) {
			if (guard is Strong_Guard) {
				i++;
			}
		}
		return i;
	}

	public int getWeakGuards ()
	{
		int i = 0;
		foreach (Guard guard in Guards) {
			if (guard is Weak_Guard) {
				i++;
			}
		}
		return i;
	}

	public int getgoods ()
	{
		return goods;
	}

	public int getgoodsvalue ()
	{
		return goods * 6;
	}

	public void setgoods (int setthegoods)
	{
		goods = setthegoods;
		GameUI.gameUI.UpdateStats ();
	}

	public int getmoney ()
	{
		return money;
	}

	public int getgoodsSpace ()
	{
		return goodsSpace;
	}

	public void stolenfrom (int goodsstolen)
	{
		goods -= goodsstolen;
		GameUI.gameUI.UpdateStats ();
	}

	public void stolenfrommoney (int moneystolen)
	{
		money -= moneystolen;
		GameUI.gameUI.UpdateStats ();
	}

	public void setmoney (int setthemoney)
	{
		money = setthemoney;
		GameUI.gameUI.UpdateStats ();
	}

	public void addgoods (int goodstoadd)
	{
		goods = (goods + goodstoadd > 20) ? 20 : goods + goodstoadd;
		GameUI.gameUI.UpdateStats ();
	}

	public void addmoney (int moneytoadd)
	{
		money += moneytoadd;
		GameUI.gameUI.UpdateStats ();
	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}
