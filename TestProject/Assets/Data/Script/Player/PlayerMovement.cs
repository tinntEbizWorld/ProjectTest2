using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 5f;

    public CharacterController controller;
    private Vector3 movement;
    private float rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkMovement();
        //movement.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //rotation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    }

    private void checkMovement()
    {
        //throw new NotImplementedException();
    }
    //private void FixedUpdate()
    //{
    //    transform.Translate(movement, Space.Self);
    //    transform.Rotate(0f, rotation, 0f);
    //}
    //private void checkMovement()
    //{
    //    float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");

    //    Vector3 move = transform.right * x + transform.forward * z;

    //    controller.Move(move * speed * Time.deltaTime);

    //}
}
