using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum GameState {
	Start,
	Game,
	Pause,
	End
}

public class GameManager : MonoBehaviour {

    public Text scoreKeep;
    public Text ballBounce;
    public Text gameOver;

    public int score;
    public int bounceCount;

	public GameState gameState;

    // Use this for initialization
    void Start () {
        score = 0;
        bounceCount = 0;
		gameState = GameState.Game;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ballBounce.text = "Bounce Count: " + bounceCount.ToString();
        scoreKeep.text = "Score: " + score.ToString();

		if (Input.GetKeyDown (KeyCode.P)) {
			if (gameState == GameState.Game) {
				gameState = GameState.Pause;
			} else if (gameState == GameState.Pause) {
				gameState = GameState.Game;
			}
		}
    }
}
