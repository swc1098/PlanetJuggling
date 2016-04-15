using UnityEngine;
using System.Collections;

public class LeaveOrbit : MonoBehaviour {

    // get the gamemanager
    private GameManager gm;

    // Use this for initialization
    void Start ()
    {
        // get the game manager script
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // when the ball leaves orbit, inform the player and then quickly turn off the message. 
    public void OnTriggerExit(Collider c)
    {
        if (c.tag == "Ball")
        {
            Debug.Log("Something left");
            gm.leaveText.gameObject.SetActive(true);
            gm.leaveText.enabled = true;
            Invoke("DisableLeaveText", 4);

            Destroy(c.gameObject);

            gm.score += 500;
        }
    }


    // simply disables the object leavetext
    public void DisableLeaveText()
    {
        gm.leaveText.gameObject.SetActive(false);
        gm.leaveText.enabled = false;

    }
}
