using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    private bool canMove = true;

    //speed to have the player move display in editor
    public float rotateSpeed = 20.0f;
    public float speed = 20.0f;

    //creates inputs variables
    private float forwardInput;
    private float rotateInput;

    void Start()
    {
        
    }

    void Update()
    {
        //getting the vertical axis
        forwardInput = Input.GetAxis("Vertical");

        //getting the horizontal axis
        rotateInput = Input.GetAxis("Horizontal");

        //calling the movement function
        if (canMove)
            Movement();
    }

    public void ChangeMove(bool canMoveThing)
    {
        canMove = canMoveThing;
    }

    void Movement()
    {
        //adds the movement to allow the player to move forward and back
        player.AddForce(transform.up * forwardInput * speed * Time.deltaTime);

        //adds the players abilty to rotate left and right
        player.MoveRotation(player.rotation - rotateInput * rotateSpeed * Time.deltaTime);
    }
}
