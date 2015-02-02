using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour {
	[SerializeField]
	protected Caravan caravan;

	[SerializeField]
	protected CaravanMapScript mapscript;

	public void Init(Caravan caravan, CaravanMapScript cms){
		this.caravan = caravan;
		mapscript = cms;
		InternalInit();
	}

	protected virtual void InternalInit(){}

	public void continuePlaying(){
		mapscript.continueAfterEvent();
		GameUI.gameUI.UpdateStats();
		Destroy(gameObject);
	}

	public void losegame(){
		caravan.addmoney (caravan.getgoodsvalue ());
		caravan.setgoods (0);
		GameOver.score = caravan.getmoney ();
		GameOver.message = "You lost!\n" +
			"What a shame!";
		Application.LoadLevel ("Gameover");
	}
}
