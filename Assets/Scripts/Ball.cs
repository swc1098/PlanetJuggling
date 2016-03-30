using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float power;

    private Rigidbody rb;

    public Text scoreKeep;
    public Text gameOver;
    public int score;

    // Use this for initialization
    void Start()
    {     
        score = 0;

        power = 10.0f;

        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        scoreKeep.text = "Bounce Count: " + score.ToString();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            Debug.Log("Success!");
            Vector3 force = new Vector3(power,power, power);
            rb.AddForce(force, ForceMode.Acceleration);
            score++;
        }

    }

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Planet")
        {
            Destroy(gameObject);
            Destroy(c.gameObject);
            Destroy(GameObject.Find("Player"));
            scoreKeep.enabled = false;
            gameOver.gameObject.SetActive(true);
            gameOver.enabled = true;
            
        }
    }
}
