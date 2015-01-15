using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Caravan : MonoBehaviour {
	[SerializeField]
	public List<Guard> guards = new List<Guard>();
	
	[SerializeField]
	int goodsSpace = 20;
	[SerializeField]
	int goods = 5;
	[SerializeField]
	int money = 25;


	// Use this for initialization
	void Start () {
	
	}

	public int getStrongGuards(){
		int i = 0;
		foreach(Guard guard in guards){
			if(guard is Strong_Guard){
				i++;
			}
		}
		return i;
	}
	public int getWeakGuards(){
		int i = 0;
		foreach(Guard guard in guards){
			if(guard is Weak_Guard){
				i++;
			}
		}
		return i;
	}

	public int getgoods(){ return goods;}

	public int getgoodsvalue(){ return goods * 6; }

	public int setgoods(int setthegoods) {return goods = setthegoods;}

	public int getmoney(){ return money;}

	public int getgoodsSpace(){ return goodsSpace;}

	public void stolenfrom(int goodsstolen){
		goods -= goodsstolen;
	}

	public void stolenfrommoney(int moneystolen){
		money -= moneystolen;
	}

	public void setmoney(int setthemoney){
		money = setthemoney;
	}

	public void addgoods(int goodstoadd){
		goods = (goods + goodstoadd > 20) ? 20 : goods + goodstoadd;
	}

	public void addmoney(int moneytoadd){
		money += moneytoadd;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
