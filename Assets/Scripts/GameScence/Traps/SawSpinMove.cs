using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpinMove : MonoBehaviour
{
    public GameObject sawMovementR;
    public GameObject sawMovementL;

    float timeToMove;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        timeToMove = 0;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        sawMovementR.transform.Rotate(0, 0, 30);                             //it's like the method transform.Translate just that this affects the rotation of the object
        sawMovementL.transform.Rotate(0, 0, 30);

        // Condition for saw movement left or right over and over again
        if (timeToMove >= 0 && timeToMove < 3.2f)
        {
            sawMovementR.transform.position = new Vector3(sawMovementR.transform.position.x + speed * Time.deltaTime, sawMovementR.transform.position.y, sawMovementR.transform.position.z);    //SawTrapMoveR goes right
            sawMovementL.transform.position = new Vector3(sawMovementL.transform.position.x - speed * Time.deltaTime, sawMovementL.transform.position.y, sawMovementL.transform.position.z);    //SawTrapMoveL goes left
            timeToMove += Time.deltaTime;
        }
        else if (timeToMove >= 3.2f && timeToMove < 6.4f)
        {
            sawMovementR.transform.position = new Vector3(sawMovementR.transform.position.x - speed * Time.deltaTime, sawMovementR.transform.position.y, sawMovementR.transform.position.z);    //SawTrapMoveR goes left
            sawMovementL.transform.position = new Vector3(sawMovementL.transform.position.x + speed * Time.deltaTime, sawMovementL.transform.position.y, sawMovementL.transform.position.z);   //SawTrapMoveL goes right
            timeToMove += Time.deltaTime;

            if (timeToMove >= 6.4f)
            {
                timeToMove = 0;
            }
        }

    }
}
