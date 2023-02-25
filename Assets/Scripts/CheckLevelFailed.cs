using UnityEngine;
using System.Collections;

public class CheckLevelFailed : MonoBehaviour {

	public GameObject explosion;

	void OnTriggerEnter2D (Collider2D other) {

		if(other.CompareTag("Enemy_1") || other.CompareTag("Enemy_2") || other.CompareTag("Enemy_3") || other.CompareTag("Enemy_4") || other.CompareTag("Enemy_5") 
			|| other.CompareTag("Enemy_6") || other.CompareTag("Enemy_7") || other.CompareTag("Enemy_8") || other.CompareTag("Enemy_9")) {

			SoundManager.instance.Sound_PlayerExplosion ();

			GUIManager.instance.Display_LevelFailedScreenX();

			GameObject cloneExplosion = Instantiate(explosion) as GameObject;
			cloneExplosion.transform.position = transform.position;
			Destroy(cloneExplosion, 2);

			GUIManager.instance.StopFiring();
			GUIManager.instance.StopSpawning_Enemy_1();

//			GUIManager.instance.Display_LevelFailedScreen();

			GUIManager.instance.listCloneEnemies.Remove (other.gameObject);
			Destroy(other.gameObject);
			Destroy(this.gameObject);

		
		}


	}
	
}