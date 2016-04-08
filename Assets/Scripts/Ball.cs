using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float power;
	public Vector3 direction;

    private Rigidbody rb;

    private GameManager GM;

	private GameObject player;

	private Vector3 tempVelocity;

    // Use this for initialization
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
		player = GameObject.FindGameObjectWithTag ("Player");
		updatePower ();

        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
		//Debug.Log (direction);

		if (GM.gameState == GameState.Pause) {
			tempVelocity = rb.velocity;
			rb.velocity = Vector3.zero;
			rb.isKinematic = true;
		} else if (GM.gameState == GameState.Game && rb.velocity == Vector3.zero) {
			rb.isKinematic = false;
			rb.velocity = tempVelocity;
		}
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
            GM.bounceCount++;
        }

    }

	void updatePower () {
		power = 100.0f * (1 + 0.05f * GM.bounceCount);
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
