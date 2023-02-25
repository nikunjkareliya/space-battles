using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	public AudioSource audioSource_1;
	public AudioSource audioSource_2;
	public AudioSource audioSource_3;
	public AudioSource audioSource_4;
	
	public AudioClip audioClip_bg;
	public AudioClip audioClip_button;
	public AudioClip audioClip_bulletShot;

	public AudioClip[] audioClip_Explosion;
	
	public static SoundManager instance;
	
	void Awake () {
		instance = this;
	}

	public void Sound_ButtonPlay () {
		audioSource_2.Play ();
	}

	public void Sound_BulletShot () {
		audioSource_3.Play ();
	}

	public void Sound_EnemyExplosion () {
//		audioSource_4.clip = audioClip_Explosion[Random.Range(0, audioClip_Explosion.Length)];
		audioSource_4.clip = audioClip_Explosion[0];
		audioSource_4.Play ();
	}

	public void Sound_PlayerExplosion () {
		//		audioSource_4.clip = audioClip_Explosion[Random.Range(0, audioClip_Explosion.Length)];
		audioSource_4.clip = audioClip_Explosion[1];
		audioSource_4.Play ();
	}
}
