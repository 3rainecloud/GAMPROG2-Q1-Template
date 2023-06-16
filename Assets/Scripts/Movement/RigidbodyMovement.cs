using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed = 5.0f;

    public float jumpForce;
    public float jumpCool;
    public float airMulti;
    bool jumpR;

    [Header("Ground Check")]
    public LayerMask Ground;
    bool groundD;

    //[SerializeField]
    //private int updateCount, fixedUpdateCount;

    Vector3 moveDirect;
    private float xMove, zMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        //Get the input values from the player
        xMove = Input.GetAxis("Horizontal") * speed;
        zMove = Input.GetAxis("Vertical") * speed;

        if (Input.GetKeyDown(KeyCode.Space) && groundD)
        {
            jumpR = false;

            Jump();

            Invoke(nameof(JumpReset), jumpCool);
        }
    }

    private void FixedUpdate()
    {
        //Change the velocity of our player
        //rb.velocity = new Vector3(xMove, rb.velocity.y, zMove);
        Vector3 movement = (transform.forward * zMove) + (transform.right * xMove);
        rb.velocity = movement;

        if (groundD)
        {
            rb.AddForce(moveDirect.normalized * speed * 10f, ForceMode.Force);
        }
        else if (!groundD)
        {
            rb.AddForce(moveDirect.normalized * speed * 10f * airMulti, ForceMode.Force);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void JumpReset()
    {
        jumpR = true;
    }
}
