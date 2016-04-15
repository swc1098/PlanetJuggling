using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlanetGravity : MonoBehaviour
{
    // the range where gravity is applied
    public float range = 10f;

    private Rigidbody self;

    private GameManager gm;
    
    // Use this for initialization
    void Start()
    {
        self = gameObject.GetComponent<Rigidbody>();

        // get the game manager script
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
		// main planet spin animation
		transform.Rotate(Vector3.up, 10f * Time.deltaTime);

        // create collision checks for everything within it's gravitational range
        Collider[] collision = Physics.OverlapSphere(transform.position, range);

        List<Rigidbody> listOfBodies = new List<Rigidbody>();

        // for each object inside of the range, get the rigidbody of said object
        foreach (Collider c in collision)
        {
            Rigidbody rb = c.attachedRigidbody;


            //if (rb != null && rb != self && !(listOfBodies.Contains(rb)) && rb != GameObject.Find("Player").GetComponent<Rigidbody>())
            // if the object is not a collectible and contains a rigidbody, have gravity affect it. 
            if (rb != null && rb != self && !(listOfBodies.Contains(rb)) && rb.tag != "Coin")
            {
                listOfBodies.Add(rb);

                Vector3 offset = gameObject.transform.position - c.gameObject.transform.position;

                rb.AddForce(offset / offset.sqrMagnitude * self.mass);

                // Debug.Log(rb);
            }
        }
    }

    // visual aid
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
