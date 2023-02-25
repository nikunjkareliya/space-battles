using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager : MonoBehaviour {

	public int currentWave = 1;
	public int playerScore = 0;
	public List<Wave> listWave;
	public static DataManager instance;

	void Awake () {
		instance = this;
	}

	[System.Serializable]
	public class Wave {
		public GameObject enemyShip;
		public int maxShips;
		public float spawningRate_Min;
		public float spawningRate_Max;
//		public float enemyShip_Speed;
//		public bool isAI;
		public bool isFiringBullet;
	}

}
