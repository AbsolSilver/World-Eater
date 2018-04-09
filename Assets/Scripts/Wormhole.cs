using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    public float speed = 10f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Wormhole 01")
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }

        if (gameObject.tag == "Wormhole 02")
        {
            transform.Rotate(Vector3.back, speed * Time.deltaTime);
        }

    }
}