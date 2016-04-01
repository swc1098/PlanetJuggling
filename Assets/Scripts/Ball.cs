using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float power;

    private Rigidbody rb;

    private GameManager gm;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        power = 10.0f;

        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("Success!");
            Vector3 force = new Vector3(power, power, power);
            rb.AddForce(force, ForceMode.Acceleration);
            gm.bounceCount++;
        }

    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Planet")
        {
            Destroy(gameObject);
            Destroy(c.gameObject);
            Destroy(GameObject.Find("Player"));
            Destroy(GameObject.Find("CoinSpawner"));
            gm.ballBounce.enabled = false;
            gm.gameOver.gameObject.SetActive(true);
            gm.gameOver.enabled = true;

        }
    }
}
