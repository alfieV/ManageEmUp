using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    public float speed;

    float horizontalInput;
    float verticalInput;
    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //verticalInput = Input.GetAxisRaw("Vertical");
        //horizontalInput = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z))
        {
            verticalInput = 1;

        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            verticalInput = -1;
        }
        else
        {
            verticalInput = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            horizontalInput = -1;
        }

        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }
        else
        {
            horizontalInput = 0;
        }

        Movement();
    }

    void Movement()
    {

        Vector2 input = new Vector2(horizontalInput, verticalInput);
        Vector2 direction = input.normalized;
        Vector2 velocity = direction * speed;

        rb2D.MovePosition(rb2D.position + velocity * Time.deltaTime);
    }
}
