using UnityEngine;
using System.Collections;

public class SpaceObjects : MonoBehaviour
{
    // gets game manager in order to increment points. 
    private GameManager gm;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider c)
    {
        // if collected, then add points and destroy game object
        if (c.gameObject.tag == "Ball")
        {
            Destroy(gameObject);
            gm.score += 50;
        }
    }
}
