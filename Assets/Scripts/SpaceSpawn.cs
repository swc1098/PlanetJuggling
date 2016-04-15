using UnityEngine;
using System.Collections.Generic;

public class SpaceSpawn : MonoBehaviour
{
    /// <summary>
    /// range = The range that allows coins to spawn
    /// smallRange = the range where coins/collectibles are not allowed to spawn
    /// </summary>
    public float range = 14.0f;
    public float smallRange = 4.0f;

    // This allows instantiation of game object
    private GameObject coin;

    // the range where objects are allowed to spawn
    private float xRange;
    private float yRange;

    // the number of coins in the map at any given time. (Might later be replaced with something more efficient)
    private int coinCount;

    // Use this for initialization
    void Start()
    {
        // a hard coded number of collectibles
        coinCount = 40;

		SpawnCoins ();
    }

	public void SpawnCoins() {
		// create collectibles on map
		for (int x = 0; x < coinCount; x++)
		{
			setRandomLocation();
			coin = (GameObject)Instantiate(Resources.Load("Coin"), new Vector3(xRange, yRange), Quaternion.Euler(0,0,45)) as GameObject;
			coin.transform.SetParent(this.transform);
		}
	}

    // Update is called once per frame
    void Update()
    {
        // create a collider that detects every object that exists within the small range
        Collider[] collision = Physics.OverlapSphere(transform.position, smallRange);

        // using this, move it somewhere else
        foreach (Collider c in collision)
        {
            Rigidbody rb = c.attachedRigidbody;
            if(rb != null && rb.tag == "Coin")
            {
                setRandomLocation();
                rb.transform.position = new Vector3(xRange, yRange);
            }
        }

    }

    // visual aid for determining positions
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, smallRange);
    }

    // simply sets random location between the allowed range
    void setRandomLocation()
    {
        xRange = Random.Range(-range, range);
        yRange = Random.Range(-range, range);
    }
}
