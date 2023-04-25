using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //need to check for touching the ground to be able to jump
            //need to check for contact with a 'Floor' tag!
            Debug.Log("TEST! with W");
            rb.AddForce(new Vector3(0f, 10f, 0f), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("TEST! with A");
            rb.AddForce(new Vector3(-.1f, 0f, 0f), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("TEST! with S");
            rb.AddForce(new Vector3(0f, -5f, 0f), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("TEST! with D");
            rb.AddForce(new Vector3(.1f, 0f, 0f), ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //need to check for contact with a 'Floor' tag!
            Debug.Log("TEST! with Space - Spring shoes!");
            rb.AddForce(new Vector3(0f, 21f, 0f), ForceMode2D.Impulse);
        }
        
    }
}
