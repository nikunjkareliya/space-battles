using UnityEngine;
using System.Collections;

public class EnemyController_5 : MonoBehaviour {

	public Transform target;
	public float enemySpeed = 10;
	public float rotateSpeed = 2;
	public int enemyDirection = 1;

	public bool isFollowing = true;
	public float followTimer = 4;
	public float minDistToFollow = 3;

	void Start () {
//		iTween.RotateBy (this.gameObject, iTween.Hash("z", 180, "islocal", true, "speed", 5, "easetype", iTween.EaseType.easeInOutSine, "looptype", iTween.LoopType.loop));             
	}
	
	void OnEnable () {
//		Invoke ("Disable", followTimer);
	}
	
	void Disable () {
		isFollowing = false;
//		Destroy (gameObject);
	}
	
	Vector3 targetDir;
	void Update () {

		if(GUIManager.instance.clonePlayership) {
			if(isFollowing) {
				targetDir = GUIManager.instance.clonePlayership.transform.position - transform.position;
				//			targetDir = target.position - transform.position;

				//			Debug.Log (targetDir.magnitude);
				if(targetDir.magnitude < minDistToFollow) {
					isFollowing = false;
				}

			}

			targetDir = targetDir.normalized;
			transform.position += targetDir * enemySpeed * Time.deltaTime;
		}

	}
}
