using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float bulletSpeed = 10;
	public int bulletDirection = 1;

	public GameObject explosion_1;
	public GameObject explosion_2;
	public GameObject explosion_3;
	public GameObject explosion_4;
	public GameObject explosion_5;
	public GameObject explosion_6;
	public GameObject explosion_7;
	public GameObject explosion_8;
	public GameObject explosion_9;
	public GameObject explosion_Player;


	public bool isPlayerBullet = true;

	void Update () {
		if(GUIManager.instance.clonePlayership) {
			transform.position += bulletDirection * Vector3.up * bulletSpeed * Time.deltaTime;			
		}

	}

	void OnTriggerEnter2D (Collider2D other) {

		if(isPlayerBullet) {

//			GUIManager.instance.clonePlayership.GetComponent<Collider2D> ().enabled = false;

			if(other.CompareTag("Enemy_1")) {

				SoundManager.instance.Sound_EnemyExplosion ();

				gameObject.SetActive(false);
				GUIManager.instance.listCloneEnemies.Remove(other.gameObject);
				Destroy(other.gameObject);

				// Add score
				DataManager.instance.playerScore += 10 * DataManager.instance.currentWave;
				GUIManager.instance.textScore_Gameplay.text = "" + DataManager.instance.playerScore;

				// Explosion
				GameObject cloneExplosion = Instantiate(explosion_1) as GameObject;
				cloneExplosion.transform.position = other.transform.position;
				Destroy(cloneExplosion, 2);

			}
			else if(other.CompareTag("Enemy_2")) {

				SoundManager.instance.Sound_EnemyExplosion ();

				gameObject.SetActive(false);
				GUIManager.instance.listCloneEnemies.Remove(other.gameObject);
				Destroy(other.gameObject);

				// Add score
				DataManager.instance.playerScore += 10 * DataManager.instance.currentWave;
				GUIManager.instance.textScore_Gameplay.text = "" + DataManager.instance.playerScore;
				// Explosion
				GameObject cloneExplosion = Instantiate(explosion_2) as GameObject;
				cloneExplosion.transform.position = other.transform.position;
				Destroy(cloneExplosion, 0.5f);
			}
			else if(other.CompareTag("Enemy_3")) {

				SoundManager.instance.Sound_EnemyExplosion ();

				other.transform.root.gameObject.SetActive(false);
				GUIManager.instance.listCloneEnemies.Remove(other.transform.root.gameObject);
				Destroy(other.transform.root.gameObject);

				// Add score
				DataManager.instance.playerScore += 10 * DataManager.instance.currentWave;
				GUIManager.instance.textScore_Gameplay.text = "" + DataManager.instance.playerScore;
				// Explosion
				GameObject cloneExplosion = Instantiate(explosion_3) as GameObject;
				cloneExplosion.transform.position = other.transform.position;
				Destroy(cloneExplosion, 0.5f);
			}
			else if(other.CompareTag("Enemy_4")) {

				SoundManager.instance.Sound_EnemyExplosion ();

				other.transform.root.gameObject.SetActive(false);
				GUIManager.instance.listCloneEnemies.Remove(other.transform.root.gameObject);
				Destroy(other.transform.root.gameObject);

				// Add score
				DataManager.instance.playerScore += 10 * DataManager.instance.currentWave;
				GUIManager.instance.textScore_Gameplay.text = "" + DataManager.instance.playerScore;
				// Explosion
				GameObject cloneExplosion = Instantiate(explosion_4) as GameObject;
				cloneExplosion.transform.position = other.transform.position;
				Destroy(cloneExplosion, 0.5f);
			}
			else if(other.CompareTag("Enemy_5")) {

				SoundManager.instance.Sound_EnemyExplosion ();

				gameObject.SetActive(false);
				GUIManager.instance.listCloneEnemies.Remove(other.gameObject);
				Destroy(other.gameObject);

				// Add score
				DataManager.instance.playerScore += 10 * DataManager.instance.currentWave;
				GUIManager.instance.textScore_Gameplay.text = "" + DataManager.instance.playerScore;
				// Explosion
				GameObject cloneExplosion = Instantiate(explosion_5) as GameObject;
				cloneExplosion.transform.position = other.transform.position;
				Destroy(cloneExplosion, 0.5f);
			}
			else if(other.CompareTag("Enemy_6")) {

				SoundManager.instance.Sound_EnemyExplosion ();

				gameObject.SetActive(false);
				GUIManager.instance.listCloneEnemies.Remove(other.transform.root.gameObject);
				Destroy(other.transform.root.gameObject);

				// Add score
				DataManager.instance.playerScore += 10 * DataManager.instance.currentWave;
				GUIManager.instance.textScore_Gameplay.text = "" + DataManager.instance.playerScore;
				// Explosion
				GameObject cloneExplosion = Instantiate(explosion_6) as GameObject;
				cloneExplosion.transform.position = other.transform.position;
				Destroy(cloneExplosion, 0.5f);
			}
			else if(other.CompareTag("Enemy_7")) {

				SoundManager.instance.Sound_EnemyExplosion ();

				gameObject.SetActive(false);
				GUIManager.instance.listCloneEnemies.Remove(other.gameObject);
				Destroy(other.gameObject);

				// Add score
				DataManager.instance.playerScore += 10 * DataManager.instance.currentWave;
				GUIManager.instance.textScore_Gameplay.text = "" + DataManager.instance.playerScore;
				// Explosion
				GameObject cloneExplosion = Instantiate(explosion_7) as GameObject;
				cloneExplosion.transform.position = other.transform.position;
				Destroy(cloneExplosion, 0.5f);
			}
			else if(other.CompareTag("Enemy_8")) {

				SoundManager.instance.Sound_EnemyExplosion ();

				gameObject.SetActive(false);
				GUIManager.instance.listCloneEnemies.Remove(other.gameObject);
				Destroy(other.gameObject);

				// Add score
				DataManager.instance.playerScore += 10 * DataManager.instance.currentWave;
				GUIManager.instance.textScore_Gameplay.text = "" + DataManager.instance.playerScore;
				// Explosion
				GameObject cloneExplosion = Instantiate(explosion_8) as GameObject;
				cloneExplosion.transform.position = other.transform.position;
				Destroy(cloneExplosion, 0.5f);
			}
			else if(other.CompareTag("Enemy_9")) {

				SoundManager.instance.Sound_EnemyExplosion ();

				gameObject.SetActive(false);
				GUIManager.instance.listCloneEnemies.Remove(other.gameObject);
				Destroy(other.gameObject);

				// Add score
				DataManager.instance.playerScore += 10 * DataManager.instance.currentWave;
				GUIManager.instance.textScore_Gameplay.text = "" + DataManager.instance.playerScore;
				// Explosion
				GameObject cloneExplosion = Instantiate(explosion_9) as GameObject;
				cloneExplosion.transform.position = other.transform.position;
				Destroy(cloneExplosion, 0.5f);
			}
		}
//		else if(!isPlayerBullet) {
//			if(other.CompareTag("Player")) {
//				SoundManager.instance.Sound_PlayerExplosion ();
//
//				X();
//
//				gameObject.SetActive(false);
////				GUIManager.instance.listCloneEnemies.Remove(other.gameObject);
//				Destroy(other.gameObject);
//				// Explosion
//				GameObject cloneExplosion = Instantiate(explosion_Player) as GameObject;
//				cloneExplosion.transform.position = other.transform.position;
//				Destroy(cloneExplosion, 1f);
//
//				// Add score
////				DataManager.instance.playerScore += 10 * DataManager.instance.currentWave;
////				GUIManager.instance.textScore_Gameplay.text = "" + DataManager.instance.playerScore;
//
////				Invoke ("X", 2);
//
//			}
//		}
//
//
	}
//
//	void X () {
//		GUIManager.instance.Display_LevelFailedScreenX ();
//	}

}
