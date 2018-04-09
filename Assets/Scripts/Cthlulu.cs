using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cthlulu : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GoodPlanet")
        {
            Destroy(other.gameObject);
            // Score decreases by 100 points

        }

        if (other.gameObject.tag == "BadPlanet")
        {
            Destroy(other.gameObject);
            // Score increases by 100 points

        }
    }

    private void Destroy(string tag)
    {
        throw new NotImplementedException();
    }
}
