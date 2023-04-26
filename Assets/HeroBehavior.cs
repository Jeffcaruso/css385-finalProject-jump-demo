using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehavior : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float moveSpeed = 10f;
    public float maxSpeed = 7f;

    [Header("Vertical Movement")]
    public float jumpForce = 15f;
    public float jumpDelay = 0.25f;
    public float runningJumpForce = 5f;

    [Header("Misc")]
    public LayerMask groundLayer;
    public float groundLength = 1.27f;  //.27
    public float linearDrag = 4f;
    public float gravity = 1f;
    public float fallMultiplier = 3f;  //was 5...
    public Vector3 colliderOffset;

    private bool onGround = true;  //false 
    private Rigidbody2D rb;
    private Vector2 direction;
    private float jumpTimer;
    

    //public bool canJumpNow = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("On ground is : " + onGround + "\n");
        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);

        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpTimer = Time.time + jumpDelay;
        }

        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));



        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     //need to check for touching the ground to be able to jump
        //     //need to check for contact with a 'Floor' tag!
        //     Debug.Log("TEST! with W");
        //     rb.AddForce(new Vector3(0f, 10f, 0f), ForceMode2D.Impulse);
        // }
        // if (Input.GetKey(KeyCode.A))
        // {
        //     Debug.Log("TEST! with A");
        //     rb.AddForce(new Vector3(-.1f, 0f, 0f), ForceMode2D.Impulse);
        // }
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     Debug.Log("TEST! with S");
        //     rb.AddForce(new Vector3(0f, -5f, 0f), ForceMode2D.Impulse);
        // }
        // if (Input.GetKey(KeyCode.D))
        // {
        //     Debug.Log("TEST! with D");
        //     rb.AddForce(new Vector3(.1f, 0f, 0f), ForceMode2D.Impulse);
        // }
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     //need to check for contact with a 'Floor' tag!
        //     Debug.Log("TEST! with Space - Spring shoes!");
        //     rb.AddForce(new Vector3(0f, 21f, 0f), ForceMode2D.Impulse);
        // }        
    }

    private void FixedUpdate()
    {
        Move(direction.x);

        if(jumpTimer > Time.time && onGround)
        {
            Jump();
        }

        ModifyPhysics();
    }

    private void Move(float horizontal)
    {
        rb.AddForce(Vector2.right * horizontal * moveSpeed);
        if (Mathf.Abs(rb.velocity.x) >= maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
            if (onGround)
            {
                //gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else
            {
                //gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        else
        {
            //gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }


    private void ModifyPhysics()
    {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if (onGround) {
            if (Mathf.Abs(direction.x) < 0.4f || changingDirections)
            {
                rb.drag = linearDrag;
            } else
            {
                rb.drag = 0f;
            }
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;
            if(rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;
            } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
    }


    private void Jump()
    {
        float runJump = (Mathf.Abs(rb.velocity.x) / maxSpeed) * runningJumpForce;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * (jumpForce + runJump), ForceMode2D.Impulse);

        jumpTimer = 0;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // Vector2 tempPos = transform.position;
        // tempPos.x += (float).5;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        // tempPos.x -= 1;
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }

}
