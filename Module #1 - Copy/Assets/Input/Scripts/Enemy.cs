using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    private int enemyHealth = 15;

    //private CharacterController characterController;
    private Vector3 enemyVelocity;
    private Animator animator;

    public GameObject enemy;

    public float speed = 3f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 2f;

    //public NavMeshAgent agent;

    public bool follow = false;

    public Transform playerTransform;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        //characterController = GetComponent<CharacterController>();
        //agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = characterController.isGrounded;
        //Vector3 movement = new Vector3(speed, 0f);
        //transform.position += movement * Time.deltaTime;
        enemyVelocity.y += gravity * Time.deltaTime;
        

        if (follow)
        {
            
            transform.LookAt(playerTransform.position);
            if (speed > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, -speed * Time.deltaTime);

            }
            
            
        }
        else
        {
            //speed = 3f;
            Vector3 moveDirection = new Vector3(speed, 0f);
            transform.LookAt(transform.position + moveDirection);
            transform.position += new Vector3(speed, 0f) * Time.deltaTime;
        }
            
            
        //transform.position += movement * Time.deltaTime;
        
            

        

        if (speed != 0f) 
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {

        //If a bullet hits this specific plane with the manually made tag, "Plane", then the bullet is destroyed on impact
        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyHealth -= 5;

            Debug.Log(enemyHealth);

            if (enemyHealth <= 0)
            {
                animator.SetBool("Death", true);
                speed = 0;
                Destroy(gameObject, 5f);
                //Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("Plane"))
        {
            Debug.Log("turnig");
            speed = -speed;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("playerhtitt");
            
        }



    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("test");
        if (other.CompareTag("Player"))
        {
            Debug.Log("ENemy notices you");
            follow = true;
            
            //transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            
        }
    }
}
