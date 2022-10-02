using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Player Settings

    [Header("Player Settings")]
    [SerializeField] float playerSpeed;

    #endregion

    #region Private Variables
    float hInput;
    float vInput;
    float screenWidth;
    #endregion

    #region Components
    Animator animator;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        GetComponents();
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        AnimationController();
    }

    void PlayerMovement() // Function for all player movment
    {
        // Getting the Horizontal and Vertical inputs
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        Vector2 movementVector = new Vector2(hInput, vInput).normalized; // Creates a Vector2 using the horizontal and vertical input and normalizes it so we don't run faster than we're supposed to
        transform.Translate(movementVector * playerSpeed * Time.deltaTime); // Translates the player using the Vector2, playerSpeed, and multiplying it by Time.deltaTime to make it FrameRate independent
    }
    void AnimationController() // Controls all player animations based on variables set in the "Player" Animator
    {
        // If we're moving right, face right. If moving left, face left. If moving AT ALL, set moving to true or else set it to False
        if (hInput > 0)
        {
            animator.SetBool("facingRight", true);
        }
        else if (hInput < 0)
        {
            animator.SetBool("facingRight", false);
        }

        if(!animator.GetBool("isMoving") && Input.mousePosition.x > screenWidth / 2)
        {
            animator.SetBool("facingRight", true);
        } else if (!animator.GetBool("isMoving") && Input.mousePosition.x < screenWidth / 2)
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
    void GetComponents() // Gets all needed components
    {
        animator = GetComponent<Animator>();
    }
}
