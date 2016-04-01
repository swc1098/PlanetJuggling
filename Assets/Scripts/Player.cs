using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    // meant for controlling player speed. 
    // Fiddle with it until it's comfortable.
    public float speed;
    public float jumpSpeed;
    public bool falling;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        falling = false;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A) && falling != true)
        {
            transform.RotateAround(GameObject.Find("MainPlanet").transform.position, new Vector3(0, 0, 1.0f), speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) && falling != true)
        {
            transform.RotateAround(GameObject.Find("MainPlanet").transform.position, new Vector3(0, 0, -1.0f), speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W) && falling != true)
        {
            rb.AddRelativeForce(Vector3.up * 120);
            falling = true;
        }
    }

    public void OnCollisionStay(Collision c)
    {
        if(c.gameObject.tag != "Coin")
        {
            falling = false;
        }
    }
}
