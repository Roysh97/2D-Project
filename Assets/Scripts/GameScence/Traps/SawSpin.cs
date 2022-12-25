using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpin : MonoBehaviour
{
    Transform playerPos;
    float playerDis;
    float range = 8;
    bool playAgain;

    public AudioSource audioManager;
    public AudioClip saw;

    GameObject Saw1 , Saw2 , Saw3;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
        Saw1 = GameObject.Find("SawTrap1");
        Saw2 = GameObject.Find("SawTrap2");
        Saw3 = GameObject.Find("SawTrap3");
    }

    // Update is called once per frame
    void Update()
    {

        Saw1.transform.Rotate(0, 0, 30);  //it's like the method transform.Translate just that this affects the rotation of the object
        Saw2.transform.Rotate(0, 0, 30); 
        Saw3.transform.Rotate(0, 0, 30);  

        // Check the distance between the game object and the player and play the sound effect if the distance is in range
        playerDis = Vector2.Distance(transform.position, playerPos.position);

        
        if (playerDis <= range)
        {
            if (playAgain == false)
            {
                audioManager.PlayOneShot(saw);
                //Debug.Log("IN RANGE");
            }

            playAgain = true;
        }
        // if player out from range stop the audio 
        if (playerDis > range && playAgain == true)
        {
            float i = range;

            i = 12;

            if (playerDis > i)
            {
                audioManager.Stop();
                playAgain = false;
                //Debug.Log("out from range");
            }
        }
    }
}
