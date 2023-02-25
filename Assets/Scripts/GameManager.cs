using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public enum GameState
	{
		HomeScreen,
		Gameplay,
		GamePauseScreen,
		LevelFailed
	};

	public GameState gameState;

	public static GameManager instance;

	void Start () {
		instance = this;
	}

	public void ChangeState (GameState gs) {
		gameState = gs;
	}
}
