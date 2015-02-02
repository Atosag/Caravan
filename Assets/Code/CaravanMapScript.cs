using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CaravanMapScript : MonoBehaviour
{	
	[SerializeField]
	List<eventPos>
		eventpositions = new List<eventPos> ();
	[SerializeField]
	SplineWalker
		splineWalker = null;
	[SerializeField]
	MapScript[]
		maps = null;
	[SerializeField]
	public MapScript
		currentMap = null;
	[SerializeField]
	eventPos
		town = null,
		pauseMenu = null;
	[SerializeField]
	int mapPart = 0, map = 0;
	GameObject dustParticles = null;

	public void continueAfterEvent ()
	{
		splineWalker.isgoing = true;
	}

	void initiateMap (MapScript mapToInit)
	{
		if(currentMap != null)
			Destroy (currentMap.gameObject);
		currentMap = mapToInit.InitMap ();
		Destroy (dustParticles);
		dustParticles = (GameObject)Instantiate (currentMap.dust);
		dustParticles.transform.parent = this.transform;
		dustParticles.transform.localPosition = new Vector3 (0, 0, 0);
		dustParticles.transform.localScale = new Vector3 (1, 1, 1);

		InitiateSpline ();
	}

	void InitiateSpline ()
	{
		eventpositions.Clear ();
		
		eventpositions.Add (new eventPos (Random.Range (0.15f, 0.35f), currentMap.GetComponent<EventList> ().getrandomevent ()));
		eventpositions.Add (new eventPos (Random.Range (0.65f, 0.85f), currentMap.GetComponent<EventList> ().getrandomevent ()));
		
		for (int j = 0; j < Random.Range(0, 2); j++) {
			eventpositions.Add (new eventPos (Random.Range (0.05f, 0.95f), currentMap.GetComponent<EventList> ().getrandomevent ()));
		}
		splineWalker.LoadNewSpline (currentMap.splinePart [mapPart].spline, currentMap.splinePart [mapPart].duration);

	}

	// Use this for initialization
	void Start ()
	{
		initiateMap (maps [map]);
		//GetComponent<ParticleSystem> ().renderer.sortingLayerName = "Foreground";
		//GetComponent<ParticleSystem> ().renderer.sortingOrder = 2;
	}
	
	// Update is called once per frame
	void Update ()
	{	
		if (Input.GetKeyDown (KeyCode.Escape) && splineWalker.isgoing) {
			splineWalker.isgoing = false;
			currentMap.PlayBackgroundMusic(false);
			pauseMenu.runEvent (GetComponent<Caravan> (), this);
		}
		for (int i = 0; i < eventpositions.Count; i++) {
			if (splineWalker.Progress >= eventpositions [i].getPosition ()) {
				splineWalker.isgoing = false;
				eventpositions [i].runEvent (GetComponent<Caravan> (), this);
				eventpositions.RemoveAt (i);
				break;
			}
		}

		//Finished a spline
		if (splineWalker.Progress >= 1) {
			if (mapPart < currentMap.splinePart.Length - 1) {
				Debug.Log("Next spline");
				//Still have more splines to follow on this map
				mapPart++;
				splineWalker.isgoing = false;
				InitiateSpline ();
				town.runEvent (GetComponent<Caravan> (), this);
			} else if (map < maps.Length - 1) {
				Debug.Log("Next map");
				//Load next map
				map++;
				mapPart = 0;
				splineWalker.isgoing = false;
				town.runEvent (GetComponent<Caravan> (), this);
				initiateMap (maps [map]);
			} else {
				Debug.Log("Won the game");
				//Won the game!!!
				GetComponent<Caravan> ().addmoney (GetComponent<Caravan> ().getgoodsvalue ());
				GetComponent<Caravan> ().setgoods (0);
				GameOver.score = GetComponent<Caravan> ().getmoney ();
				GameOver.message = "Congratulations!\n" +
					"You beat the game!";
				Application.LoadLevel ("Gameover");
			}
		}
	}

	[System.Serializable]
	private class eventPos
	{
		[SerializeField]
		float
			pos;
		[SerializeField]
		Events
			eventToHappen;
		
		public eventPos (float pos, Events eventToHappen)
		{
			this.pos = pos;
			this.eventToHappen = eventToHappen;
		}
		
		public float getPosition ()
		{
			return pos;
		}
		
		public void runEvent (Caravan caravan, CaravanMapScript cms)
		{
			Events ev = (Events)GameObject.Instantiate (eventToHappen);
			ev.Init (caravan, cms);
		}
	}
}
