using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D playerController;

    public float jumpCoefficient;
    public float movementCoefficient;
    public float rotationCoefficient;
    public int maxVelocity;

    public Transform left_foot;
    public Transform right_foot;
    public LayerMask ground_layers;

    Vector2 gravity;

    // Use this for initialization
    void Start() {
        playerController = GetComponent<Rigidbody2D>();
        gravity = Physics2D.gravity;
    }

    // Update is called once per frame
    void Update() {
    }

    private void FixedUpdate() {


        float h = Input.GetAxis("Horizontal");

        bool grounded = Physics2D.OverlapArea(left_foot.position, right_foot.position, ground_layers);
        print(grounded);
        if (!grounded || Math.Abs(playerController.rotation) < 5) {
            playerController.velocity = new Vector2(h * movementCoefficient * 10, playerController.velocity.y);
        } else {
            playerController.velocity = Quaternion.AngleAxis(playerController.rotation, Vector3.forward) * new Vector2(h * movementCoefficient * 10, playerController.velocity.y);
        }
        

        if (grounded) {
            //Physics2D.gravity = Vector2.zero;
            if (Input.GetButton("Jump"))
                playerController.AddForce(Vector2.up * jumpCoefficient * 100);
        }// else if (Physics2D.gravity == Vector2.zero)
          //  Physics2D.gravity = gravity;


        float rotation = Input.GetAxis("Mouse ScrollWheel");
        playerController.AddTorque(rotation * rotationCoefficient * 10);
    }
}
