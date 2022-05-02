using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player all over the game
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y +1, -10);

    }
}



