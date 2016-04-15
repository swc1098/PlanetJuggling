using UnityEngine;
using System.Collections;

public class SpaceMove : MonoBehaviour {
    public float speed = 0;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        // offset the texture based on the passage of time. 
        gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector3(Time.time * speed, 0.0f);

	}
}
