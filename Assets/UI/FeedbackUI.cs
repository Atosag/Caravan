using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FeedbackUI : MonoBehaviour {
	public static FeedbackUI feedbackUI;
	[SerializeField]
	private Animator animator;
	[SerializeField]
	Text textField = null;


	// Use this for initialization
	void Start () {
		feedbackUI = this;
		animator = GetComponent<Animator>();
	}

	public void ShowText(string text){
		textField.text = text;
		animator.SetTrigger("Show");
	}
}
