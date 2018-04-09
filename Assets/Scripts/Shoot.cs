using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject pulsePrefab;

    private List<GameObject> Pulses = new List<GameObject>();

    public Transform bulletSpawn;

    private float pulseSpeed = 3;

    public float pulseRate = 0.5f;

    private float nextPulse = 0.0f;

    void Start()
    {
        pulseSpeed = 3;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && Time.time > nextPulse)
        {
            GameObject pulse = (GameObject)Instantiate(pulsePrefab, transform.position, bulletSpawn.transform.rotation);
            Pulses.Add(pulse);
            nextPulse = Time.time + pulseRate;
        }

        for (int i = 0; i < Pulses.Count; i++)
        {
            GameObject goPulse = Pulses[i];
            if (goPulse != null)
            {
                goPulse.transform.Translate(new Vector3(0, 1) * Time.deltaTime * pulseSpeed);

                Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goPulse.transform.position);

                if (bulletScreenPos.y >= Screen.height)
                {
                    DestroyObject(goPulse);
                    Pulses.Remove(goPulse);
                }               
            }
        }
    }
}
