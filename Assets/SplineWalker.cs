using UnityEngine;
using System.Collections.Generic;

public class SplineWalker : MonoBehaviour {

	public bool isgoing = true;

	public BezierSpline spline;

	public float duration;

	public bool lookForward;

	public SplineWalkerMode mode;
	
	private float progress;
	private bool goingForward = true;

	public float Progress 
	{
		get 
		{ 
			return progress; 
		}
	}

	public void LoadNewSpline(BezierSpline bs, float duration){
		this.spline = bs;
		this.duration = duration;
		ResetProgress();
	}

	public void ResetProgress(){
		progress = 0;
	}

	private void Update () {
		if(isgoing){
			if (goingForward) {
				progress += Time.deltaTime / duration;
				if (progress > 1f) {
					if (mode == SplineWalkerMode.Once) {
						progress = 1f;
					}
					else if (mode == SplineWalkerMode.Loop) {
						progress -= 1f;
					}
					else {
						progress = 2f - progress;
						goingForward = false;
					}
				}
			}
			else {
				progress -= Time.deltaTime / duration;
				if (progress < 0f) {
					progress = -progress;
					goingForward = true;
				}
			}

			Vector3 position = spline.GetPoint(progress);
			transform.localPosition = position;
			if (lookForward) {
				transform.LookAt(position + spline.GetDirection(progress));
			}
		}
	}
}