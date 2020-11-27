using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController characterController;

    [SerializeField]
    Animator playerAnimator;

    public float speed = 9.0f;
    public float rotateSpeed = 30f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            playerAnimator.SetBool("isJumping", true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAnimator.SetBool("isJumping", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnimator.SetBool("Forward", true);
            //playerAnimator.SetFloat("Velocity", characterController.velocity.magnitude);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnimator.SetBool("Forward", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnimator.SetBool("Backwards", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnimator.SetBool("Backwards", false);
        }

        playerAnimator.SetInteger("Velocity", Mathf.Abs((int) characterController.velocity.magnitude));
    }
}
