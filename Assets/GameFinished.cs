using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameFinished : MonoBehaviour
{
	[SerializeField]
	Text
		scoreBoard, message;

	void Start ()
	{
		message.text = GameOver.message;
		scoreBoard.text = string.Format (scoreBoard.text, GameOver.score);
	}
}