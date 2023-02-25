using UnityEngine;
using System.Collections;

public class EnemyController_2 : MonoBehaviour {

	public float enemySpeed = 10;
	public int enemyDirection = 1;

	public float rotateSpeed = 10;
	
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
	
	// Update is called once per frame
	void Update () {
		transform.position += enemyDirection * Vector3.up * enemySpeed * Time.deltaTime;		

		transform.Rotate (Vector3.forward * rotateSpeed, Space.Self);
	}
}
