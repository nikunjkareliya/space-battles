using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	public List<GameObject> listCloneEnemies;
	public Image imageFade;
	[Header("Core Variable")]
	public GameObject playership;
	public float playerShip_speed = 10;
	public Transform spawnPoint_Playership;

	public GameObject[] enemyShip;
	public float min, max;
	public float leftEdge, rightEdge, upEdge, downEdge;

	public Text textWaveNum;
	public Text textScore_Gameplay;
	public Text textScore_LevelFailed;

	[Header("UI")]
	public GameObject UIHomeScreen;
	public GameObject UIGameplayScreen;
	public GameObject UIGamePauseScreen;
//	public GameObject UILevelCompletedScreen;
	public GameObject UILevelFailedScreen;

	public GameObject UIWaveDisplay;

	[Header("Clones")]
	public GameObject clonePlayership;

	[Header("References")]
	private GameManager gameManager;
	private DataManager dataManager;
	public static GUIManager instance;

	// Use this for initialization
	void Start () {

		instance = this;
		gameManager = GameManager.instance;
		dataManager = DataManager.instance;

		leftEdge = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, 0)).x;
		rightEdge = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, 0)).x;
		upEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - 1;
		downEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + 1;

		leftEdge += playership.GetComponent<Renderer> ().bounds.size.x / 2;
		rightEdge -= playership.GetComponent<Renderer> ().bounds.size.x / 2;
	}

	#region CameraFade
//	IEnumerator routineFade;
//	public void CameraClose () {
//		if(routineFade != null) {
//			StopCoroutine(routineFade);
//		}
//		routineFade = CameraFade (0);
//		StartCoroutine (routineFade);
//	}
	
//	public void CameraOpen () {
//		if(routineFade != null) {
//			StopCoroutine(routineFade);
//		}
//		routineFade = CameraFade (1);
//		StartCoroutine (routineFade);
//	}

//	IEnumerator CameraFade (int x) {

////		yield return new WaitForSeconds (.2f);

//		for (float t = 2; t >= 0; t -= Time.deltaTime) {
//			Color tmp = imageFade.color;
//			if(x == 1)
//				tmp.a = Mathf.MoveTowards(tmp.a, 0, 1.5f * Time.deltaTime);
//			else if(x == 0)
//				tmp.a = Mathf.MoveTowards(tmp.a, 1, 1.5f * Time.deltaTime);
//			imageFade.color = tmp;
//			yield return 0;
//		}
//	}
	#endregion

	#region HomeScreen
	void CleanUp () {

		StopFiring ();
		StopSpawning_Enemy_1 ();

		OffsetScroller.instance.Stop_ScrollingX ();

		for(int i = 0; i < listCloneEnemies.Count; i++) {
			Destroy(listCloneEnemies[i].gameObject);
		}
		listCloneEnemies.Clear ();

		for(int i = 0; i < GenericPooler.instance.listPooledObjects.Count; i++) {
			Destroy(GenericPooler.instance.listPooledObjects[i].gameObject);
		}
		GenericPooler.instance.listPooledObjects.Clear ();

		for(int i = 0; i < GenericPooler_EnemyBullet.instance.listPooledObjects.Count; i++) {
			Destroy(GenericPooler_EnemyBullet.instance.listPooledObjects[i].gameObject);
		}
		GenericPooler_EnemyBullet.instance.listPooledObjects.Clear ();

		if(clonePlayership) {
			Destroy(clonePlayership);
		}

	}

	void StartPlaying () {

		SoundManager.instance.audioSource_1.Stop ();
		SoundManager.instance.audioSource_1.Play ();
		CleanUp ();
		GenericPooler.instance.CreatePool ();
		GenericPooler_EnemyBullet.instance.CreatePool ();


		dataManager.currentWave = 1;

		dataManager.playerScore = 0;
		textScore_Gameplay.text = "" + dataManager.playerScore;

		Display_GameplayScreen ();

		Display_WavePanel ();

		clonePlayership = Instantiate (playership) as GameObject;
		clonePlayership.transform.position = spawnPoint_Playership.position;
		clonePlayership.transform.rotation = Quaternion.identity;


        if (routineFiring != null)
        {
            StopCoroutine(routineFiring);
        }
        routineFiring = StartFiring();
        StartCoroutine(routineFiring);

        if (routineSpawnEnemy_1 != null) {
			StopCoroutine(routineSpawnEnemy_1);
		}
		routineSpawnEnemy_1 = StartSpawning_Enemy_1 ();
		StartCoroutine (routineSpawnEnemy_1);

		OffsetScroller.instance.Start_ScrollingX ();		
	}

	IEnumerator routineFiring;
	IEnumerator StartFiring () {

		while (true) {

			if (clonePlayership) {

				SoundManager.instance.Sound_BulletShot ();

				GameObject cloneBullet = GenericPooler.instance.GetPooledObject ();
				cloneBullet.SetActive (true);
				//				cloneBullet.transform.position = clonePlayership.transform.position + new Vector3(0, .5f, 0);
				cloneBullet.transform.position = clonePlayership.transform.position + new Vector3 (0, 1f, 0);

				yield return new WaitForSeconds (0.3f);
			}	
		}
	}

	public void StopFiring () {
		if(routineFiring != null) {
			StopCoroutine(routineFiring);
		}
	}

	IEnumerator routineSpawnEnemy_1;
	IEnumerator StartSpawning_Enemy_1 () {

		yield return new WaitForSeconds (1);

		Debug.Log ("Wave: " + dataManager.currentWave);
		for(int i = dataManager.listWave[dataManager.currentWave - 1].maxShips; i > 0; i--) {
			GameObject cloneEnemy = Instantiate(dataManager.listWave[dataManager.currentWave - 1].enemyShip) as GameObject;
			listCloneEnemies.Add(cloneEnemy);
//			cloneEnemy.transform.position = new Vector3 (Random.Range(min, max), 6, 0);

			cloneEnemy.transform.position = new Vector3 (Random.Range(leftEdge, rightEdge), 6, 0);
			cloneEnemy.transform.eulerAngles = new Vector3(0, 0, 180);

//			yield return new WaitForSeconds(Random.Range(1, 2));
			yield return new WaitForSeconds(Random.Range(dataManager.listWave[dataManager.currentWave - 1].spawningRate_Min, dataManager.listWave[dataManager.currentWave - 1].spawningRate_Max));
		}

		yield return new WaitForSeconds (1);

		dataManager.currentWave += 1;

		if (dataManager.currentWave == 10) {

			CleanUp ();
			//Invoke ("CameraClose", .2f);			
			Display_HomeScreen();
			//Invoke ("CameraOpen", 1.5f);

		} else {
			Display_WavePanel();
			NextWave();			
		}


	}

	public void StopSpawning_Enemy_1 () {
		if(routineSpawnEnemy_1 != null) {
			StopCoroutine(routineSpawnEnemy_1);
		}
	}

	void NextWave () {

		if(routineSpawnEnemy_1 != null) {
			StopCoroutine(routineSpawnEnemy_1);
		}
		routineSpawnEnemy_1 = StartSpawning_Enemy_1 ();
		StartCoroutine (routineSpawnEnemy_1);
	}

	public void ButtonPlay_HomeScreen () {
		SoundManager.instance.Sound_ButtonPlay ();
		//Invoke ("CameraClose", .2f);
		StartPlaying();
		//Invoke ("CameraOpen", 1.5f);
	}
	
	public void ButtonExit_HomeScreen () {
		SoundManager.instance.Sound_ButtonPlay ();
		Application.Quit ();
	}

	public void Display_HomeScreen () {
		CleanUp ();
		gameManager.ChangeState (GameManager.GameState.HomeScreen);

		UIHomeScreen.SetActive (true);
		UIGameplayScreen.SetActive (false);
		UIGamePauseScreen.SetActive (false);
//		UILevelCompletedScreen.SetActive (false);
		UILevelFailedScreen.SetActive (false);
		UIWaveDisplay.SetActive (false);
	}
	#endregion

	#region Gameplay
	public void Display_GameplayScreen () {
		OffsetScroller.instance.Start_ScrollingX ();

		Time.timeScale = 1;
		gameManager.ChangeState (GameManager.GameState.Gameplay);

		UIHomeScreen.SetActive (false);
		UIGameplayScreen.SetActive (true);
		UIGamePauseScreen.SetActive (false);
//		UILevelCompletedScreen.SetActive (false);
		UILevelFailedScreen.SetActive (false);
		UIWaveDisplay.SetActive (false);
	}

	public void Display_WavePanel () {

		if(gameManager.gameState == GameManager.GameState.Gameplay) {
			UIWaveDisplay.SetActive (true);

			textWaveNum.text = "" + dataManager.currentWave;
			Invoke ("HideWavePanel", 2);
		}

	}

	void HideWavePanel () {
		UIWaveDisplay.SetActive (false);
	}
	#endregion

	#region LevelFailed
	public void Display_LevelFailedScreen () {
		//		Debug.Log ("fjbghkfrgjhjgfkrgjlfhij");
		if (routineFiring != null)
		{
			StopCoroutine(routineFiring);
		}

		CleanUp ();
		gameManager.ChangeState (GameManager.GameState.LevelFailed);
		
		UIHomeScreen.SetActive (false);
		UIGameplayScreen.SetActive (false);
		UIGamePauseScreen.SetActive (false);
		//		UILevelCompletedScreen.SetActive (false);
		UILevelFailedScreen.SetActive (true);
		UIWaveDisplay.SetActive (false);

		textScore_LevelFailed.text = "" + dataManager.playerScore;
	}

	public void ButtonReplay_LevelFailedScreen () {
		SoundManager.instance.Sound_ButtonPlay ();
		//Invoke ("CameraClose", .2f);
		StartPlaying();
		//Invoke ("CameraOpen", 1.5f);
	}

	public void ButtonMenu_LevelFailedScreen () {
		SoundManager.instance.Sound_ButtonPlay ();
		//Invoke ("CameraClose", .2f);
		Display_HomeScreen();
		//Invoke ("CameraOpen", 1.5f);
	}
	#endregion

	#region Gameplay
	public void ButtonPause_Gameplay () {
		SoundManager.instance.Sound_ButtonPlay ();
		Display_PauseScreen ();
	}

	public void Display_PauseScreen () {

		OffsetScroller.instance.Stop_ScrollingX ();

		Debug.Log ("Display_PauseScreen");
		Time.timeScale = 0;
		gameManager.ChangeState (GameManager.GameState.GamePauseScreen);
		
		UIHomeScreen.SetActive (false);
		UIGamePauseScreen.SetActive (true);
		UILevelFailedScreen.SetActive (false);
		UIWaveDisplay.SetActive (false);
	}

	public void ButtonResume_GamePause () {
		SoundManager.instance.Sound_ButtonPlay ();
		Display_GameplayScreen ();
	}

	public void ButtonMenu_GamePause () {
		SoundManager.instance.Sound_ButtonPlay ();
		Time.timeScale = 1;
		CleanUp ();
		Display_HomeScreen ();
	}
	#endregion

	#region Player Control
	bool isTouch = false;
	public void TouchDown () {

		//if(GameManager.instance.gameState == GameManager.GameState.Gameplay) {
		//	isTouch = true;

		//	if(routineFiring != null) {
		//		StopCoroutine(routineFiring);
		//	}
		//	routineFiring = StartFiring ();
		//	StartCoroutine (routineFiring);
		//}

	}

	public void TouchUp () {
		//isTouch = false;

		//if(routineFiring != null) {
		//	StopCoroutine(routineFiring);
		//}
	}
	#endregion

	bool isExecuteOnce = false;
	void Update () {


		//if(isTouch && clonePlayership) {
		//	Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//	v3 = new Vector3(v3.x, v3.y + .5f, 0);
		//	clonePlayership.transform.position = Vector3.MoveTowards(clonePlayership.transform.position, v3, Time.deltaTime * playerShip_speed);// * playerShip_speed * Time.deltaTime;
		//}		

		float xVal = Input.GetAxis ("Horizontal");
		float yVal = Input.GetAxis ("Vertical");

		Vector3 inputKeyboard = new Vector3 (xVal, yVal, 0);

		if (clonePlayership != null) {
			clonePlayership.transform.position += inputKeyboard * playerShip_speed * Time.deltaTime;
			Vector3 tmpPos = clonePlayership.transform.position;
			tmpPos.x = Mathf.Clamp (tmpPos.x, leftEdge, rightEdge);
			tmpPos.y = Mathf.Clamp (tmpPos.y, downEdge, upEdge);
			clonePlayership.transform.position = tmpPos;
		}
		/*
		if(Input.GetKeyUp(KeyCode.Space)) {
//			Destroy(clonePlayership.gameObject); 

			if(clonePlayership) {

				GameObject cloneBullet = GenericPooler.instance.GetPooledObject ();
				cloneBullet.SetActive (true);
				cloneBullet.transform.position = clonePlayership.transform.position + new Vector3(0, .5f, 0);

				SoundManager.instance.Sound_BulletShot ();

				Debug.Log ("Fire. . .");			
			}

		}*/

		//		if(Input.GetKeyUp(KeyCode.Escape)) {
		//
		//			if(gameManager.gameState == GameManager.GameState.Gameplay) {
		//				Time.timeScale = 0;
		//				Display_PauseScreen();
		//			}
		//			else if(gameManager.gameState == GameManager.GameState.GamePauseScreen) {
		//				Time.timeScale = 1;
		//				Display_GameplayScreen();
		//			}
		//		}

	}

	public void Display_LevelFailedScreenX () {
//		Debug.Log ("hebcdjdbvik");
		Invoke ("Display_LevelFailedScreen", 1);
		//Display_LevelFailedScreen();
	}
}
