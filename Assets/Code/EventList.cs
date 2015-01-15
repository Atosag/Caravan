using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventList : MonoBehaviour {

	//List with events
	[SerializeField]
	List<Events> analpussy = new List<Events>();

	public Events getrandomevent(){
		Events eventToReturn = analpussy[Random.Range(0, analpussy.Count)];
		analpussy.Remove(eventToReturn);
		return eventToReturn;
	}
}
