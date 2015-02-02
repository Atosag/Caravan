using UnityEngine;
using System.Collections;

public class MapScript : MonoBehaviour
{
	[SerializeField]
	public SplinePart[]
		splinePart = null;

	[SerializeField]
	Color backgroundColor = Color.black;

	[SerializeField]
	public GameObject dust = null;

	public MapScript InitMap(){
		Camera.main.backgroundColor = backgroundColor;
		return (MapScript)GameObject.Instantiate(this);
	}

	public void PlayBackgroundMusic(bool isPlaying)	{
		if(isPlaying)
			GetComponent<AudioSource>().Play();
		else
			GetComponent<AudioSource>().Pause();
	}
}

[System.Serializable]
public class SplinePart
{
	[SerializeField]
	public BezierSpline
		spline = null;
	[SerializeField]
	public float
		duration = 0;
}
