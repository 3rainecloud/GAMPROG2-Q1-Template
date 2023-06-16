using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private float gravityScale = 1.0f;

    private float gravity = -9.8f;

    public float jumpSpeed = 15;
    bool canJump = true;

    private CharacterController characterController;

    public float playerHeight;
    public LayerMask watIsGround;
    bool groundD;

    Vector3 moveVelocity;

    Rigidbody rb;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump"))
        {
            moveVelocity.y = jumpSpeed;
        }
        moveVelocity.y += gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);

        if (!characterController.isGrounded)
        {
            canJump = false;
        }
    }

    private void Move()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.right * xMove) + (transform.forward * zMove);
        moveDirection.y += gravity * Time.deltaTime * gravityScale;
        moveDirection *= moveSpeed * Time.deltaTime;

        //Debug.Log(moveDirection);
        characterController.Move(moveDirection);
    }
}