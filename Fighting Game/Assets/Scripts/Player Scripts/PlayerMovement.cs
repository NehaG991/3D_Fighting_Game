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


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
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
