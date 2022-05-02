using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpinMove : MonoBehaviour
{
    public GameObject sawMovementR;
    public GameObject sawMovementL;

    float sawMoves;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        sawMoves = 0;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        sawMovementR.transform.Rotate(0, 0, 30);  //it's like the method transform.Translate just that this affects the rotation of the object
        sawMovementL.transform.Rotate(0, 0, 30);

        // Condition for saw movement left or right over and over again
        if (sawMoves >= 0 && sawMoves < 160)
        {
            sawMovementR.transform.position = new Vector3(sawMovementR.transform.position.x + speed * Time.deltaTime, sawMovementR.transform.position.y, sawMovementR.transform.position.z);
            sawMovementL.transform.position = new Vector3(sawMovementL.transform.position.x - speed * Time.deltaTime, sawMovementL.transform.position.y, sawMovementL.transform.position.z);
            sawMoves++;
        }
        else if (sawMoves >= 160 && sawMoves < 320)
        {
            sawMovementR.transform.position = new Vector3(sawMovementR.transform.position.x - speed * Time.deltaTime, sawMovementR.transform.position.y, sawMovementR.transform.position.z);
            sawMovementL.transform.position = new Vector3(sawMovementL.transform.position.x + speed * Time.deltaTime, sawMovementL.transform.position.y, sawMovementL.transform.position.z);
            sawMoves++;

            if (sawMoves >= 320)
            {
                sawMoves = 0;
            }
        }

    }


}
