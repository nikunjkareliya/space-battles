using UnityEngine;
using System.Collections;

public class EnemyController_10 : MonoBehaviour {

	public Transform[] path;

	public float enemySpeed = 10;
//	public float rotateSpeed = 2;
	public int enemyDirection = 1;
	
	void Start () {
//		iTween.moveto

		iTween.MoveTo ( gameObject, 
			iTween.Hash(
				"path", path,
				"time", 10,
				"easetype", iTween.EaseType.linear,
				"oncomplete", "Disable",
				"oncompletetarget", this.gameObject
			));

		Start_FireX ();

		//		iTween.RotateBy (this.gameObject, iTween.Hash("z", 180, "islocal", true, "speed", 5, "easetype", iTween.EaseType.easeInOutSine, "looptype", iTween.LoopType.loop));
	}
	
//	void OnEnable () {
//		Invoke ("Disable", 4);
//	}
//	
	void Disable () {
		GUIManager.instance.listCloneEnemies.Remove (gameObject);
		Destroy (gameObject);
	}
	
	void Start_FireX () {
		if(routine_Fire != null) {
			StopCoroutine (routine_Fire);
		}
		routine_Fire = Fire ();
		StartCoroutine (routine_Fire);
	}

	public void Stop_FireX () {
		if(routine_Fire != null) {
			StopCoroutine (routine_Fire);
		}

	}

	IEnumerator routine_Fire;
	IEnumerator Fire () {

		yield return new WaitForSeconds (1f);

		while(true) {
			GameObject cloneBullet = GenericPooler_EnemyBullet.instance.GetPooledObject ();
			cloneBullet.SetActive (true);
			cloneBullet.transform.position = transform.position + new Vector3 (0, -1, 0);
			cloneBullet.transform.rotation = transform.rotation;

			yield return new WaitForSeconds (.7f);


		}
	}
}
