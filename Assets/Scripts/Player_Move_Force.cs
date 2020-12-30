using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Move_Force : MonoBehaviour
{

    public float speed;             //Floating point variable to store the player's movement speed.

    private float moveHorizontal;
    private float moveVertical;

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Store the current horizontal input in the float moveHorizontal.
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        //Store the current vertical input in the float moveVertical.
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {

        rb2d.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
    }
}