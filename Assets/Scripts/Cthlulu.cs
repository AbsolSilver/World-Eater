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
            Destroy(gameObject);
            // Score decreases by 100 points

        }

        if (other.gameObject.tag == "BadPlanet")
        {
            Destroy(gameObject);
            // Score increases by 100 points

        }
    }
}
