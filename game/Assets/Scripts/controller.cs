using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public Rigidbody player;
    public float jumpForce = 6f;
    
    private float zSpeed = 5f;
    private float xSpeed = 5f;
    private float moveForce = 2f;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            MoveForwardAndBack();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            MoveLeftAndRight();
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            JumpCommand();
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void MoveForwardAndBack()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        player.MovePosition(transform.position + input * Time.deltaTime * zSpeed);
    }

    private void MoveLeftAndRight()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        player.MovePosition(transform.position + input * Time.deltaTime * xSpeed);
    }

    private void JumpCommand()
    {
        player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
            
        var currentHorizontalVelocity = Input.GetAxis("Horizontal");
        var currentVerticalVelocity = Input.GetAxis("Vertical");

        player.AddForce(Vector3.right * currentHorizontalVelocity * moveForce);
        player.AddForce(Vector3.forward * currentVerticalVelocity * moveForce);
    }
}
