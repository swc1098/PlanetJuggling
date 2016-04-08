using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    // UI text to keep track of
    public Text scoreKeep;
    public Text ballBounce;
    public Text gameOver;

    // int to be parsed into strings
    public int score;
    public int bounceCount;

    // Use this for initialization
    void Start () {
        score = 0;
        bounceCount = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // update scores
        ballBounce.text = "Bounce Count: " + bounceCount.ToString();
        scoreKeep.text = "Score: " + score.ToString();
    }
}
