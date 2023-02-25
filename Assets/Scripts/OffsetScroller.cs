using UnityEngine;
using System.Collections;

public class OffsetScroller : MonoBehaviour {

//	public float scrollSpeed;
//	private Vector2 savedOffset;
//
//	void Start () {
//		savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset ("_MainTex");
//	}
//
//	void Update () {
//		float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
////		Vector2 offset = new Vector2 (savedOffset.x, y);
//		Vector2 offset = new Vector2 (x, savedOffset.y);
//		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
//	}
//
//	void OnDisable () {
//		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
//	}

	public float speed;
	float pos = 0;

	public static OffsetScroller instance;

	void Awake () {
		instance = this;	

//		Start_ScrollingX ();
	}
		
	public void Start_ScrollingX() {

		if (routine_Scrolling != null) {
			StopCoroutine (routine_Scrolling);
		}

		routine_Scrolling = Start_Scrolling ();
		StartCoroutine (routine_Scrolling);
	}
		
	public void Stop_ScrollingX() {
	
		if (routine_Scrolling != null) {
			StopCoroutine (routine_Scrolling);
		}
	}

	IEnumerator routine_Scrolling;
	IEnumerator Start_Scrolling () {

		while (true) {
			pos += speed;
			if(pos > 1) {
				pos -= 1;
			}

			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, pos);	

			yield return new WaitForSeconds(0);
		}
	}
		
}