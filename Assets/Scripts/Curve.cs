using UnityEngine;
using System.Collections;

public class Curve : MonoBehaviour {

	public AnimationCurve animCurveX;
	public AnimationCurve animCurveY;
	public bool canRotate;
	public float rotateSpeed;

	
	void Start () {
//		iTween.RotateBy (this.gameObject, iTween.Hash("z", 180, "islocal", true, "speed", 5, "easetype", iTween.EaseType.easeInOutSine, "looptype", iTween.LoopType.loop));             
	}
	
//	void OnEnable () {
//		Invoke ("Disable", 4);
//	}
//	
//	void Disable () {
//		Destroy (gameObject);
//	}

	float t = 0;
	float x, y;
	// Update is called once per frame
	void Update () {

		if(canRotate) {
			transform.Rotate (Vector3.forward * rotateSpeed, Space.Self);
		}

		x = animCurveX.Evaluate (t);
//		y = animCurveY.Evaluate (t);

		if (DataManager.instance.currentWave == 6) {
			y = animCurveY.Evaluate (t);			
		} else {
			y = 0;
		}

		t += Time.deltaTime;

		transform.localPosition = new Vector3 (x, 0, 0);
	}
}
