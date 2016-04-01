using UnityEngine;
using System.Collections;

public class SpaceObjects : MonoBehaviour
{
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
        if (c.gameObject.tag == "Ball")
        {
            Destroy(gameObject);
            gm.score += 50;
        }
    }
}
