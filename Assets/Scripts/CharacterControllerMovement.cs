using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float gravityScale = 1.0f;
    private float xMove, zMove;

    private float gravity = -9.8f;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        //Get the input values from the player
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        Vector3 movementDir = (transform.forward * zMove) + (transform.right * xMove);
        //apply the gravity
        movementDir.y += gravity * gravityScale;
        movementDir *= speed * Time.deltaTime;
        controller.Move(movementDir);
    }
}
