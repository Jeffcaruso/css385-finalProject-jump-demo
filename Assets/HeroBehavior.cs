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
            Debug.Log("TEST! with W");
            rb.AddForce(new Vector3(0f, 5f, 0f), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("TEST! with A");
            rb.AddForce(new Vector3(-5f, 0f, 0f), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("TEST! with S");
            rb.AddForce(new Vector3(0f, -5f, 0f), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("TEST! with D");
            rb.AddForce(new Vector3(5f, 0f, 0f), ForceMode2D.Impulse);
        }
        
    }
}
