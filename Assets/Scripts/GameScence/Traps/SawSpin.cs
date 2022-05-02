using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpin : MonoBehaviour
{
    Transform playerPos;
    float playerDis;
    float range;
    bool playAgain;

    public AudioSource audioManager;
    public AudioClip saw;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player").transform;

        range = 8f;
        playAgain = true;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 0, 30);  //it's like the method transform.Translate just that this affects the rotation of the object

        // Check the distance between the game object and the player and play the sound effect if the distance is in range
        playerDis = Vector2.Distance(transform.position, playerPos.position);

        
        if (playerDis <= range)
        {
            if (playAgain)
            {
                audioManager.PlayOneShot(saw);
                Debug.Log("IN RANGE");
            }

            playAgain = false;
        }
        // if player out from range stop the audio 
        if (playerDis > range && playAgain == false)
        {
            float i = range;
            i = 20;

            if (playerDis > i)
            {
                audioManager.Stop();
                playAgain = true;
                Debug.Log("out from range");
            }
        }
    }
}
