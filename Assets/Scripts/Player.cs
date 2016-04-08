using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    // meant for controlling player speed. 
    // Fiddle with it until it's comfortable.
    public float speed;

    // check if player is currently falling
    public bool falling;

    // for force manipulaton on gameobject
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        // player is not jumping or falling
        falling = false;

        // find player's rigidbody
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // basic movement around planet
        if (Input.GetKey(KeyCode.A) && falling != true)
        {
            transform.RotateAround(GameObject.Find("MainPlanet").transform.position, new Vector3(0, 0, 1.0f), speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) && falling != true)
        {
            transform.RotateAround(GameObject.Find("MainPlanet").transform.position, new Vector3(0, 0, -1.0f), speed * Time.deltaTime);
        }

        // add force to player's jump
        if (Input.GetKey(KeyCode.W) && falling != true)
        {
            rb.AddRelativeForce(Vector3.up * 120);
            falling = true;
        }
    }

    // make sure that the player's falling bool is not affected by touching collectibles
    public void OnCollisionStay(Collision c)
    {
        if(c.gameObject.tag != "Coin")
        {
            falling = false;
        }
    }
}
