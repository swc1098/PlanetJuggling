using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum GameState
{
	Start,
	Game,
	Pause,
	Win,
	Lose
}

public class GameManager : MonoBehaviour
{

	// UI text to keep track of
	public Text scoreKeep;
	public Text ballBounce;
	public Text gameOver;
	public Text information;
	public Text leaveText;

	// camera settings
	public float maxCameraZoom;
	public float minCameraZoom;

	// a check to see if game needs to be zoomed
	public bool zoomed = false;

	// keep track of game state
	public GameState gameState;
	private GameState currentState;
	private GameState previousState;

	// menus & buttons
	private Dictionary<GameState, GameObject> menus;
	private GameObject[] startButton;
	private GameObject[] menuButton;
	private GameObject[] resumeButton;
	private GameObject[] restartButton;

	// int to be parsed into strings
	public int score;
	public int bounceCount;

	// Scene objects
	private SpaceSpawn coinSpawner;
	private Player player;

	// Use this for initialization
	void Start ()
	{
		// Scene objects
		coinSpawner = GameObject.Find("CoinSpawner").GetComponent<SpaceSpawn>();
		player = GameObject.Find("Player").GetComponent<Player>();

		// Menus
		menus = new Dictionary<GameState, GameObject> ();
		menus.Add (GameState.Start, GameObject.Find ("MainMenu"));
		menus.Add (GameState.Game, GameObject.Find ("GameMenu")); // placeholder
		menus.Add (GameState.Pause, GameObject.Find ("PauseMenu"));
		menus.Add (GameState.Win, GameObject.Find ("VictoryMenu"));
		menus.Add (GameState.Lose, GameObject.Find ("GameOverMenu"));
		foreach (GameObject m in menus.Values) {
			m.GetComponent<RectTransform>().localPosition = Vector3.zero;
		}

		// Start --> Game
		startButton = GameObject.FindGameObjectsWithTag ("StartButton");
		foreach (GameObject button in startButton) {
			button.GetComponent<Button>().onClick.AddListener(() => { // anonymous (delegate) function!
				ChangeState (GameState.Game);
				NewGame ();
			});
		}

		// ___ --> Start
		menuButton = GameObject.FindGameObjectsWithTag ("MenuButton");
		foreach (GameObject button in menuButton) {
			button.GetComponent<Button>().onClick.AddListener(() => { // anonymous (delegate) function!
				ChangeState (GameState.Start);
			});
		}

		// Pause --> Game
		resumeButton = GameObject.FindGameObjectsWithTag ("ResumeButton");
		foreach (GameObject button in resumeButton) {
			button.GetComponent<Button>().onClick.AddListener(() => { // anonymous (delegate) function!
				ChangeState (GameState.Game);
			});
		}

		// ___ --> Game
		restartButton = GameObject.FindGameObjectsWithTag ("RestartButton");
		foreach (GameObject button in restartButton) {
			button.GetComponent<Button>().onClick.AddListener(() => { // anonymous (delegate) function!
				ChangeState (GameState.Game);
				NewGame ();
			});
		}

		// keep the main camera as always orthographic
		Camera.main.orthographic = true;
		minCameraZoom = 8;
		maxCameraZoom = 12.5f;

		// Set active menu to start game
		ChangeState (GameState.Game);
	}

	void NewGame ()
	{
		// initial settings
		score = 0;
		bounceCount = 0;
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		foreach (GameObject ball in balls) {
			Destroy (ball);
		}
		GameObject[] coins = GameObject.FindGameObjectsWithTag ("Coin");
		foreach (GameObject coin in coins) {
			Destroy (coin);
		}
		coinSpawner.SpawnCoins ();
		player.ResetPos ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentState = gameState;
		if (currentState != previousState) {
			/*
			switch (currentState) {
			case GameState.Start:
				Debug.Log ("Start");
				break;
			case GameState.Game:
				Debug.Log ("Game");
				break;
			case GameState.Pause:
				Debug.Log ("Pause");
				break;
			case GameState.Win:
				Debug.Log ("Win");
				break;
			case GameState.Lose:
				Debug.Log ("Lose");
				break;
			}*/
		}

		if (gameState == GameState.Game) {

			// update scores
			ballBounce.text = bounceCount.ToString ();
			scoreKeep.text = score.ToString ();

			// just a check to see whether or not to zoom. Calls methods accordingly.
			if (zoomed == true) {
				zoomOut ();
			} else {
				zoomIn ();
			}

		}

		// Check for pause state
		if (Input.GetKeyDown (KeyCode.P)) {
			if (gameState == GameState.Game) {
				ChangeState(GameState.Pause);
			} else if (gameState == GameState.Pause) {
				ChangeState(GameState.Game);
			}
		}

		previousState = currentState;
	}
		
	//
	//
	// CHANGE GAMESTATE HERE
	//
	//
	public void ChangeState(GameState state) {
		gameState = state;

		foreach (GameObject m in menus.Values) {
			m.SetActive(false);
		}

		menus[state].SetActive(true);
	}


	// handles zoom sloppily. It's a placeholder until we refine it.
	public void OnTriggerExit (Collider c)
	{
		if (c.tag == "Ball" && zoomed == false) {
			zoomed = true;
			gameState = GameState.Game;
		}
	}

	public void OnTriggerEnter (Collider c)
	{
		if (c.tag == "Ball" && zoomed == true) {
			zoomed = false;
		}
	}

	// Figure out the camera's current position and then lerp to desired zoomsize
	public void zoomOut ()
	{
		for (float i = minCameraZoom; i < maxCameraZoom; i++) {
			Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, maxCameraZoom, Time.deltaTime);
		}
	}

	// Figure out the camera's current position and then lerp to desired zoomsize
	public void zoomIn ()
	{
		for (float i = maxCameraZoom; i > minCameraZoom; i--) {
			Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, minCameraZoom, Time.deltaTime);
		}
	}
}
