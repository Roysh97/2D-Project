using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Transform playerPos;
    float playerDis;
    float range;
    bool playAgain;

    public AudioSource audioSource;
    public AudioClip fire;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player").transform;

        range = 10f;
        playAgain = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Check the distance between the game object and the player and play the sound effect if the distance is in range
        playerDis = Vector2.Distance(transform.position, playerPos.position);

        if (playerDis <= range && playAgain == true)
        {                                             //if player gets closer to the fire the sound will be played
            audioSource.PlayOneShot(fire);

            playAgain = false;                    //if player gets away from the fire the sound will be not played
        }
        if (playerDis > range && playAgain == false)   //if player gets away from the fire the sound will be stoped from  playing
        {
            audioSource.Stop();

            playAgain = true;              //if player gets closer to the fire the sound will be played
        }
    }
}

