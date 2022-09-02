using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameManager gameManager; // Reference to the GameManager script

    public float jumpPower;

    private Animator animator;
    private Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // animator.SetTrigger("Jump");
            animator.SetBool("isJumping", true);
            rigidBody2D.AddForce(Vector2.up * jumpPower);
        }
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("isJumping", false);
        }

        if(collision.gameObject.tag == "Obstacle")
        {
            // animator.SetBool("isDead", true);
            gameManager.isDead = true;
        }
    }
}
