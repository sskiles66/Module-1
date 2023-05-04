using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController characterController;
    private Vector3 playerVelocity;
    private Animator animator;

    public GameObject player;
    
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 2f;

   //public Actions actions;
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
       // actions = GetComponent<Actions>();


    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = characterController.isGrounded;
        //Debug.Log(gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name);


    }

    //Receives inputs for InputManager.cs and applies them to character controller.
    public void ProcessMove(Vector2 input)
    {
         
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        
        playerVelocity.y += gravity * Time.deltaTime;

        if (moveDirection != Vector3.zero)
        {
            characterController.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
            

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {

                speed = 10f;
                //player.GetComponent<Animator>().SetTrigger("WalkTri");
                //player.GetComponent<Animator>().Play("Run");

                
                
            }
            else
            {
                speed = 5f;
                //player.GetComponent<Animator>().Play("Walk");
                animator.SetBool("IsMoving", true);




            }

        }
        else
        {
            //player.GetComponent<Animator>().Play("Aiming");
            animator.SetBool("IsMoving", false);
        }


        if (isGrounded && playerVelocity.y < 0) 
        {   
            playerVelocity.y = -2f;

        }

        if (playerVelocity.y > 0)
        {

            //player.GetComponent<Animator>().Play("Jump");
            animator.SetBool("IsJumping", true);

        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
        


        

        //Getting rid of this makes it so player can't jump.
        characterController.Move(playerVelocity * Time.deltaTime);
        
    }

    public void Jump()
    {
        if (isGrounded)
        {
            
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

}
