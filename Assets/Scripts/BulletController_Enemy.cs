using UnityEngine;
using System.Collections;

public class BulletController_Enemy : MonoBehaviour {

	public float bulletSpeed = 10;
	public int bulletDirection = -1;

	public GameObject explosion_Player;

//	public bool isPlayerBullet = true;

	void Update () {
		if (GUIManager.instance.clonePlayership) {
			transform.position += bulletDirection * Vector3.up * bulletSpeed * Time.deltaTime;		
		}

	}

	void OnTriggerEnter2D (Collider2D other) {

		if(other.CompareTag("Player")) {
			SoundManager.instance.Sound_PlayerExplosion ();

			X();

			gameObject.SetActive(false);
			other.GetComponent<Renderer> ().enabled = false;

			for(int i = 0; i < GenericPooler.instance.listPooledObjects.Count; i++) {
				GenericPooler.instance.listPooledObjects [i].GetComponent<Renderer> ().enabled = false;
				GenericPooler.instance.listPooledObjects [i].GetComponent<Collider2D> ().enabled = false;
			}

			GameManager.instance.gameState = GameManager.GameState.LevelFailed;
//			Destroy(other.gameObject);

			// Explosion
			GameObject cloneExplosion = Instantiate(explosion_Player) as GameObject;
			cloneExplosion.transform.position = other.transform.position;
			Destroy(cloneExplosion, 1f);

			// Add score
//				DataManager.instance.playerScore += 10 * DataManager.instance.currentWave;
//				GUIManager.instance.textScore_Gameplay.text = "" + DataManager.instance.playerScore;

//				Invoke ("X", 2);

		}


	}

	void X () {
		GUIManager.instance.Display_LevelFailedScreenX ();
	}

}
