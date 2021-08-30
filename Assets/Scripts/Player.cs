using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public float jumpspeed = 2f;
    public bool IsGrounded;
    public bool Correct;
    public bool Option;
    public bool Answered;

    private Quiz_Manager quizManager;
    private Gate gate;

    private float movement;
    private Rigidbody2D rigidBody;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        quizManager = FindObjectOfType<Quiz_Manager>();
        gate = FindObjectOfType<Gate>();
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            spriteRenderer.flipX = false;
        }
        else if (movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            spriteRenderer.flipX = true;            
        }

        if (Input.GetKey(KeyCode.Space) && IsGrounded == true)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpspeed);
        }

        if (IsGrounded)
        {
            anim.SetBool("Jump", false);
        }   
        else
        {
            anim.SetBool("Jump", true);
        }

        if (rigidBody.velocity.x >= 0.01 && IsGrounded || rigidBody.velocity.x <= -0.01 && IsGrounded)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if(Answered == false)
        {
            if (Correct == true && Input.GetKeyUp(KeyCode.Return))
            {
                if (Option == true)
                {
                    Debug.Log("Correct ans");

                    Answered = true;
                    quizManager.Correct();

                    rigidBody.velocity = new Vector2(0, 2f);
                }
            }
            if (Correct == false && Input.GetKeyUp(KeyCode.Return))
            {
                if (Option == true)
                {
                    Debug.Log("Wrong ans");

                    Answered = true;
                    quizManager.Wrong();

                    rigidBody.velocity = new Vector2(0, 2f);
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Option"))
        {
            IsGrounded = true;
        }

        if(collision.gameObject.CompareTag("Option")) 
        {
            if (collision.gameObject.GetComponent<Answers>().isCorrect == true)
            {
                Option = true;
                Correct = true;
            }
            else if (collision.gameObject.GetComponent<Answers>().isCorrect == false)
            {
                Option = true;
                Correct = false;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
        if (collision.gameObject.CompareTag("Option"))
        {
            Option = false;
            IsGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Exit"))
        {
            gate.GameOverScore();
        }
    }
}
