using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float Speed;
    public Animator animator;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (hor != 0 || ver != 0)
        {
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
        }

        //Vector3 playerMovement = new Vector3(transform.position.x + hor, 0f, transform.position.z + ver) * Speed * Time.deltaTime * 100;
        //rb.MovePosition(playerMovement);

        // 2. Create the move vector
        // /!\ Input Horizontal axis positive button
        //      need to be the right move button (right arrow, D, ...)
        Vector3 moveVector = (transform.forward * ver) + (transform.right * hor);
        moveVector *= Speed * Time.deltaTime;

        // 3. Apply the mouvement to the local position
        rb.velocity = moveVector;
    }
}
