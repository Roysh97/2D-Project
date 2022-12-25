using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesManager : MonoBehaviour
{
    public GameObject player01;
    public GameObject zombie01;
    public GameObject zombie01Rise;
    public GameObject zombie02;
    public GameObject zombie03;

    public GameObject zombie01Trapped;
    public GameObject zombie03Trapped;

    float x;
    float disX;
    float disX2;

    public AudioSource audioSource;
    public AudioClip bloodSound;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(zombie01, zombie01.transform.position, zombie01.transform.rotation);
        Instantiate(zombie01, new Vector2(zombie01.transform.position.x + 16, zombie01.transform.position.y), zombie01.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
         // Instantiate all the zombies by triggers all over the map
    }

    public void TwoZombiesTrigger()
    {
        Instantiate(zombie01Rise, new Vector2(player01.transform.position.x - 4, zombie01Rise.transform.position.y), zombie01Rise.transform.rotation);
        Instantiate(zombie01Rise, new Vector2(player01.transform.position.x + 4, zombie01Rise.transform.position.y), zombie01Rise.transform.rotation);
    }

    public void ZombieTrigger()
    {
        int i = 6;

        disX = 5;

        while (i > 0)
        {

            Instantiate(zombie01Rise, new Vector2(player01.transform.position.x - disX, zombie01Rise.transform.position.y), zombie01Rise.transform.rotation);

            disX -= -2;

            i--;
        }
    }
    
    public void MultiZombiesTriggerR()
    {
        int i = 12;

        disX2 = 5;

        while (i > 0)
        {
            x = Random.Range(-1f, 22f);

            Instantiate(zombie01Rise, new Vector2(player01.transform.position.x + disX2, -20), zombie01Rise.transform.rotation);

            disX2 += 2;

            i--;
        }

        i = 2;

        while (i > 0)
        {
            x = Random.Range(39f, 54f);

            Instantiate(zombie03, new Vector3(x, -20f, 0), zombie03.transform.rotation);

            i--;
        }

        i = 1;

        if (i == 1)
        {
            Instantiate(zombie03Trapped, new Vector2(51.2f, -61.595f), zombie03Trapped.transform.rotation);          // all trapped zombies in game  
            Instantiate(zombie01Trapped, new Vector3(48.08f, -17.32f, 2f), zombie01Trapped.transform.rotation);

            i--;
        }
    }

    public void MultiZombiesTrigger2()
    {
        int i = 3;

        while (i > 0)
        {
            x = Random.Range(104, 111);
           
            Instantiate(zombie02, new Vector2(x, -56.7f), zombie02.transform.rotation);

            i--;
        }

        i = 4;

        while (i > 0)
        {
            x = Random.Range(69, 81);
            
            Instantiate(zombie03, new Vector2(x, -58.22f), zombie03.transform.rotation);

            i--;
        }

        i = 2;

        while (i > 0)
        {
            x = Random.Range(93, 105);
         
            Instantiate(zombie03, new Vector2(x, -61.35f), zombie03.transform.rotation);
            Instantiate(zombie01, new Vector2(x, -61.35f), zombie01.transform.rotation);

            --i;
        }
    }

    public void MultiZombiesTrigger3()
    {
        int i = 2;

        while (i > 0)
        {
            x = Random.Range(148, 160);
           
            Instantiate(zombie02, new Vector2(x, -56.96f), zombie02.transform.rotation);

            i--;
        }

        i = 4;

        while (i > 0)
        {
            x = Random.Range(146, 163);

            Instantiate(zombie03, new Vector2(x, -61.32f), zombie03.transform.rotation);

            i--;
        }
    }

    // Function for zombie blood sound effect
    public void BloodSound()
    {
        audioSource.PlayOneShot(bloodSound);
    }
}
