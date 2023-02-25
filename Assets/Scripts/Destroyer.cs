using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Bullet_Player")) {
			other.gameObject.SetActive (false);
		} else if(other.CompareTag("Bullet_Enemy")) {
			other.gameObject.SetActive (false);
		} 
		else if(other.CompareTag("Enemy_7") || other.CompareTag("Enemy_8") || other.CompareTag("Enemy_9") || other.CompareTag("Enemy_10")) {
			print ("Nothing");
		}
		else {
			GUIManager.instance.listCloneEnemies.Remove (other.transform.root.gameObject);
			Destroy (other.transform.root.gameObject);
		}
	}
}
