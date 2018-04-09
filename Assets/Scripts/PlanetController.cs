using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] planets;
    public float spawnRate = 1f;
    public float spawnRadius = 5f;

    void Spawn()
    {
        Vector3 rand = Random.insideUnitSphere * spawnRadius;
        rand.z = 0f;
        Vector3 position = transform.position + rand;
        int randIndex = Random.Range(0, planets.Length);
        GameObject randPlanet = planets[randIndex];
        GameObject clone = Instantiate(randPlanet);
        clone.transform.position = position;
    }

    void Start()
    {
        InvokeRepeating("Spawn", 0, spawnRate);
    }

}

