using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;
}

public class Move : MonoBehaviour
{

    public float speed;
    public float tilt;
    public Boundary boundary;


    void FixedUpdate()
    {
        // Getting the Rigidbody2D from the player
        Rigidbody rigid = GetComponent<Rigidbody>();

        // this variable is equal to moving the player on the horizontal axis
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        // Setting the speed rate
        rigid.velocity = movement * speed;


        // Setting the speed rate
        rigid.velocity = movement * speed;

        Vector3 bounds = new Vector3((Mathf.Clamp(rigid.position.x, boundary.xMin, boundary.xMax)), 0.0f, 0.0f);

        rigid.position = bounds;

        rigid.rotation = Quaternion.Euler(0.0f, 0.0f, rigid.velocity.x * -tilt);
    }
}


