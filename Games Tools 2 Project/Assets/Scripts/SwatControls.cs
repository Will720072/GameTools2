using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatControls : MonoBehaviour {

    static Animator anim;
    public float speed = 1.0f;
    public float rotationSpeed = 10.0f;

    private CharacterController controller;
    private float gravity = 12.0f;
    private float verticalVelocity = 0.0f;

    // Use this for initialization
    void Start ()
    {
	   anim = GetComponent<Animator>();

       controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //moveVector.y = verticalVelocity;

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }

        if(translation != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

	}
}
