using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01 : MonoBehaviour
{
    float speed;
    float x;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            speed = 5;
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            speed = 5;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, 350f));
        }
    }
}
