using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesManager : MonoBehaviour
{
    public GameObject player01;
    public GameObject zombie01;
    public GameObject zombie01Patrol;
    public GameObject zombie01Rise;
    public GameObject zombie02;
    public GameObject zombie03;

    int numOfZombies;
    float x;
    float y;

    public AudioSource audioSource;
    public AudioClip bloodSound;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(zombie01, zombie01.transform.position, zombie01.transform.rotation);
        Instantiate(zombie01Patrol, zombie01Patrol.transform.position, zombie01Patrol.transform.rotation);

        numOfZombies = 3;
    }

    // Update is called once per frame
    void Update()
    {
         // Instantiate all the zombies by triggers all over the map
    }

    public void ZombieTrigger()
    {
        Instantiate(zombie01Rise, new Vector2(player01.transform.position.x - 4, zombie01Rise.transform.position.y), zombie01Rise.transform.rotation);
    }

    public void TwoZombiesTrigger()
    {
        Instantiate(zombie01Rise, new Vector2(player01.transform.position.x - 4, zombie01Rise.transform.position.y), zombie01Rise.transform.rotation);
        Instantiate(zombie01Rise, new Vector2(player01.transform.position.x + 4, zombie01Rise.transform.position.y), zombie01Rise.transform.rotation);
    }
    
    public void MultiZombiesTriggerR()
    {
        int i = numOfZombies;

        if (i == 3)
        {
            while (i > 0)
            {
                x = Random.Range(-5f, 22f);
                y = Random.Range(-20f, -20f);

                Instantiate(zombie01, new Vector2(x, y), zombie01.transform.rotation);
                Instantiate(zombie01Patrol, new Vector2(x, y), zombie01Patrol.transform.rotation);

                i--;
            }
        }

        i = 2;

        if (i == 2)
        {
            while (i > 0)
            {
                x = Random.Range(39f, 54f);
                y = Random.Range(-20f, -20f);

                Instantiate(zombie03, new Vector3(x, y , 0), zombie03.transform.rotation);

                i--;
            }
        }

        i = 1;

        if (i == 1)
        {
            Instantiate(zombie03, new Vector2(51.2f, -61.595f), zombie03.transform.rotation);
            Instantiate(zombie01Patrol, new Vector3(44.38f, -17.97f, 2f), zombie01Patrol.transform.rotation);

            i--;
        }
    }

    public void MultiZombiesTrigger2()
    {
        int i = numOfZombies;
        i = 2;

        while (i > 0)
        {
            x = Random.Range(104, 111);
            y = Random.Range(-56.7f, -56.7f);

            Instantiate(zombie02, new Vector2(x, y), zombie02.transform.rotation);

            i--;
        }

        i = 2;

        while (i > 0)
        {
            x = Random.Range(76.75f, 80.77f);
            y = Random.Range(-58.22f, -58.22f);

            Instantiate(zombie03, new Vector2(x, y), zombie03.transform.rotation);

            i--;
        }

        i = 1;

        while (i > 0)
        {
            x = Random.Range(94.44f, 104);
            y = Random.Range(-61.35f, -61.35f);

            Instantiate(zombie03, new Vector2(x, y), zombie03.transform.rotation);
            Instantiate(zombie01, new Vector2(x, y), zombie01.transform.rotation);

            --i;
        }
    }

    public void MultiZombiesTrigger3()
    {
        Instantiate(zombie02, new Vector2(158, -57.84f), zombie02.transform.rotation);

        int i = numOfZombies;
        i = 4;

        while (i > 0)
        {
            x = Random.Range(151.71f, 163);

            Instantiate(zombie03, new Vector2(x, -61.32f), zombie03.transform.rotation);

            i--;
        }
    }

    public void MultiZombiesTrigger4()
    {
        int i = numOfZombies;
        i = 5;

        while (i > 0)
        {
            x = Random.Range(214.5f, 236.43f);

            Instantiate(zombie02, new Vector2(x, -62.9f), zombie02.transform.rotation);

            i--;
        }
    }

    // Function for zombie blood sound effect
    public void BloodSound()
    {
        audioSource.PlayOneShot(bloodSound);
    }
}
