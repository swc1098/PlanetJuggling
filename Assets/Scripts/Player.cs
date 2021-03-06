﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    // meant for controlling player speed. 
    // Fiddle with it until it's comfortable.
    public float speed;
    public float jumpSpeed;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(GameObject.Find("MainPlanet").transform.position, new Vector3(0, 0, 1.0f), speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(GameObject.Find("MainPlanet").transform.position, new Vector3(0, 0, -1.0f), speed * Time.deltaTime);
        }
        /*
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed, Space.Self);
        }
        */
    }
}
