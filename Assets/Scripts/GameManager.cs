using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

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

    // check to see if game is in a start state
    public bool start = true;

    // int to be parsed into strings
    public int score;
    public int bounceCount;

    // Use this for initialization
    void Start ()
    {
        // initial settings
        minCameraZoom = 8;
        maxCameraZoom = 12.5f;
        score = 0;
        bounceCount = 0;

        // keep the main camera as always orthographic
        Camera.main.orthographic = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
        // update scores
        ballBounce.text = bounceCount.ToString();
        scoreKeep.text = score.ToString();

        // just a check to see whether or not to zoom. Calls methods accordingly.
        if (zoomed == true)
        {
            zoomOut();
        }

        if (zoomed == false && start == false)
        {
            zoomIn();
        }
    }


    // handles zoom sloppily. It's a placeholder until we refine it.
    public void OnTriggerExit(Collider c)
    {
        if(c.tag == "Ball" && zoomed == false)
        {
            zoomed = true;
            start = false;
        }
    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Ball" && zoomed == true)
        {
            zoomed = false;
        }
    }

    // Figure out the camera's current position and then lerp to desired zoomsize
    public void zoomOut()
    {
        for (float i = minCameraZoom; i < maxCameraZoom; i++)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, maxCameraZoom, Time.deltaTime);
        }
    }

	// Figure out the camera's current position and then lerp to desired zoomsize
    public void zoomIn()
    {
        for (float i = maxCameraZoom; i > minCameraZoom; i--)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, minCameraZoom, Time.deltaTime);
        }
    }
}
