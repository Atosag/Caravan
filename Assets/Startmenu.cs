using UnityEngine;
using System.Collections;

public class Startmenu : MonoBehaviour {

	void Start(){
		GetComponent<AudioSource> ().Play ();
	}

	// Use this for initialization
	public void StartGame () {
		Application.LoadLevel("Caravanmain");
	}

	public void QuitGame() {
		Application.Quit();
	}

}
