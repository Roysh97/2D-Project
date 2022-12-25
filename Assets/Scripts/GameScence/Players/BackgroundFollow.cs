using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform followPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the player all over the game
        transform.position = new Vector3(followPlayer.transform.position.x, followPlayer.transform.position.y +1 , 10);
    }
}
