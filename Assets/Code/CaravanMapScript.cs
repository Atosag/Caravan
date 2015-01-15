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
	SplinePart[]
		splinePart = null;
	[SerializeField]
	eventPos
		town = null,
		pauseMenu = null;
	int mapPart = 0;

	public void continueAfterEvent ()
	{
		splineWalker.isgoing = true;
	}

	void initiatepath ()
	{
		eventpositions.Clear ();

		eventpositions.Add (new eventPos (Random.Range (0.15f, 0.35f), GetComponent<EventList> ().getrandomevent ()));
		eventpositions.Add (new eventPos (Random.Range (0.65f, 0.85f), GetComponent<EventList> ().getrandomevent ()));

		for (int j = 0; j < Random.Range(0, 2); j++) {
			eventpositions.Add (new eventPos (Random.Range (0.05f, 0.95f), GetComponent<EventList> ().getrandomevent ()));
		}
		splineWalker.LoadNewSpline (splinePart [mapPart].spline, splinePart [mapPart].duration);
	}

	// Use this for initialization
	void Start ()
	{
		initiatepath ();
		GetComponent<ParticleSystem> ().renderer.sortingLayerName = "Foreground";
		GetComponent<ParticleSystem> ().renderer.sortingOrder = 2;
	}
	
	// Update is called once per frame
	void Update ()
	{	
		if (Input.GetKeyDown (KeyCode.Escape) && splineWalker.isgoing) {
			splineWalker.isgoing = false;
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

		if (splineWalker.Progress >= 1) {
			if (mapPart < splinePart.Length - 1) {
				mapPart++;
				splineWalker.isgoing = false;
				initiatepath ();
				town.runEvent (GetComponent<Caravan> (), this);
			} else {
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
	private class SplinePart
	{
		[SerializeField]
		public BezierSpline
			spline = null;
		[SerializeField]
		public float
			duration = 0;
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
