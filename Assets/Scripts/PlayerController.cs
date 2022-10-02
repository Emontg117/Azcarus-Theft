using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hInput;
    public float vInput;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GetComponents();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement() // Function for all player movment
    {
        // Getting the Horizontal and Vertical inputs
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if (hInput > 0)
        {
            animator.SetBool("facingRight", true);
        }
        else if (hInput < 0)
        {
            animator.SetBool("facingRight", false);
        }

        if (vInput != 0 || hInput != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
    void GetComponents()
    {
        animator = GetComponent<Animator>();
    }
}
