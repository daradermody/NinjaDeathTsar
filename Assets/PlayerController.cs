using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D playerController;

    public float jumpCoefficient;
    public float movementCoefficient;

    public Transform bottom;
    public LayerMask ground_layers;

    void Start() {
        playerController = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        ControlMovement();
        ControlJump();
    }

    private void ControlMovement() {
        float h = Input.GetAxis("Horizontal");
        playerController.velocity = new Vector2(h * movementCoefficient * 10, playerController.velocity.y);
    }

    private bool IsGrounded() {
        return Physics2D.OverlapPoint(bottom.position, ground_layers);
    }

    private void ControlJump() {
        if (Input.GetButton("Jump") && IsGrounded())
            playerController.AddForce(Vector2.up * jumpCoefficient * 100);
    }
}
