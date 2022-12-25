using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFollow : MonoBehaviour
{
    public GameObject player; //Drag the player GO here in the Inspector  

    public void LateUpdate()
    {
        transform.position = new Vector2(player.transform.position.x , player.transform.position.y + 1.2f );
    }

}
