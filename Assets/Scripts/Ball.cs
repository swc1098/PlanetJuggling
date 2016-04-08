using UnityEngine;
using System.Collections;

// From Sung
// DOCUMENT YOUR CODE!!!!!!!!!

public class Ball : MonoBehaviour
{

    public float power;
	public Vector3 direction;

    private Rigidbody rb;

    private GameManager gm;

	private GameObject player;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		player = GameObject.FindGameObjectWithTag ("Player");
		updatePower ();

        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
		//Debug.Log (direction);
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            //Debug.Log("Success!");
            //Vector3 force = new Vector3(power, power, power);
			//rb.AddForce(power * direction, ForceMode.Acceleration);

			direction = (transform.position - player.transform.position).normalized;
			updatePower ();
			rb.velocity = Vector3.zero;
			rb.AddForceAtPosition(power * direction, transform.position);
            gm.bounceCount++;
        }

    }

	void updatePower () {
		power = 100.0f * (1 + 0.05f * gm.bounceCount);
	}

    void OnCollisionEnter(Collision c)
    {
        //if (c.gameObject.tag == "Planet")
        //{
        //    Destroy(gameObject);
        //    Destroy(c.gameObject);
        //    Destroy(GameObject.Find("Player"));
        //    Destroy(GameObject.Find("CoinSpawner"));
        //    gm.scoreKeep.enabled = false;
        //    gm.ballBounce.enabled = false;
        //    gm.gameOver.gameObject.SetActive(true);
        //    gm.gameOver.enabled = true;
		//
        //}
    }
}
