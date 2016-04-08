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

    // This allows instantiation of game object
    private GameObject ball;

    // get game manager
    private GameManager gm;


    // Use this for initialization
    void Start()
    {
        // player is not jumping or falling
        falling = false;

        // find player's rigidbody
        rb = gameObject.GetComponent<Rigidbody>();

        // get the game manager script
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        if (Input.GetKeyDown(KeyCode.W) && falling != true)
        {
            //rb.AddRelativeForce(Vector3.up * 120);
            //falling = true;
            // spawns object on top of player. 
            ball = (GameObject)Instantiate(Resources.Load("Ball"), gameObject.transform.position * 2, Quaternion.identity) as GameObject;

            gm.information.enabled = false;
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
