using UnityEngine;
using System.Collections;

public class EnemyController_1 : MonoBehaviour {

	public float enemySpeed = 10;
	public int enemyDirection = 1;
	
	void Start () {
		transform.eulerAngles = new Vector3 (0, 0, 180);
		Start_FireX ();
//		iTween.RotateTo (this.gameObject, iTween.Hash("z", 360, "islocal", true, "speed", 1, "easetype", iTween.EaseType.easeInOutSine, "looptype", iTween.LoopType.loop));             
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

			yield return new WaitForSeconds (1f);


		}
	}
}
