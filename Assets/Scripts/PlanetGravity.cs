using UnityEngine;
using System.Collections.Generic;

public class PlanetGravity : MonoBehaviour {

    public float range = 10f;
    Rigidbody self;

	// Use this for initialization
	void Start ()
    {
        self = gameObject.GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        Collider[] collision = Physics.OverlapSphere(transform.position, range);

        List<Rigidbody> listOfBodies = new List<Rigidbody>();

        foreach (Collider c in collision)
        {
            Rigidbody rb = c.attachedRigidbody;


            //if (rb != null && rb != self && !(listOfBodies.Contains(rb)) && rb != GameObject.Find("Player").GetComponent<Rigidbody>())
            if (rb != null && rb != self && !(listOfBodies.Contains(rb)))
            {
                listOfBodies.Add(rb);

                Vector3 offset = gameObject.transform.position - c.gameObject.transform.position;

                rb.AddForce(offset / offset.sqrMagnitude * self.mass);

               // Debug.Log(rb);
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
