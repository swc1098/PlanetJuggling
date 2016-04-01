using UnityEngine;
using System.Collections.Generic;

public class SpaceSpawn : MonoBehaviour
{

    public float range = 10.0f;
    public float smallRange = 4.0f;

    private GameObject coin;

    private float xRange;
    private float yRange;

    // the number of coins in the map at any given time. (Might later be replaced with something more efficient)
    private int coinCount;

    // Use this for initialization
    void Start()
    {
        coinCount = 40;


        for (int x = 0; x < coinCount; x++)
        {
            setRandomLocation();
            coin = (GameObject)Instantiate(Resources.Load("Coin"), new Vector3(xRange, yRange), Quaternion.identity) as GameObject;
            coin.transform.SetParent(GameObject.Find("CoinSpawner").transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] collision = Physics.OverlapSphere(transform.position, smallRange);

        List<Rigidbody> listOfBodies = new List<Rigidbody>();

        foreach (Collider c in collision)
        {
            Rigidbody rb = c.attachedRigidbody;
            if(rb.tag == "Coin")
            {
                setRandomLocation();
                rb.transform.position = new Vector3(xRange, yRange);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, smallRange);
    }

    void setRandomLocation()
    {
        xRange = Random.Range(-range, range);
        yRange = Random.Range(-range, range);
    }
}
