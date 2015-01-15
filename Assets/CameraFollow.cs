using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	[SerializeField]
	MonoBehaviour caravan = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//TODO: Maybe parent instead?
		Vector3 toPosition = caravan.transform.position;
		toPosition.z = -10;
		transform.position = toPosition;
	}
}
