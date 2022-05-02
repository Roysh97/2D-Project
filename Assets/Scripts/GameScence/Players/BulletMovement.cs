using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    float speed = 8;

    Transform playerScalex;

    bool dir;

    Transform playerPos;

    float x;
    float range;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        range = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        // Shot the bullet from the side of the player
       if(dir == true)
       {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
       }

       else if(dir == false)
       {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
       }

       // When the bullet moves away from the player
        x = Vector2.Distance(transform.position, playerPos.position);

        if (x > range)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        // The condition for the side of the player
        playerScalex = GameObject.Find("Player").transform;

        if (playerScalex.transform.localScale.x > 0)
        {
            dir = true;
        }
        else
        {
            dir = false;
        }
    }

}

