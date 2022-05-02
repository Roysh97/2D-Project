using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie02 : MonoBehaviour
{
    private Transform playerPos;    // Check where is the player position
    GameObject playerScale;        // Check what is the player scale

    float speed;
    float playerDis;             // Check what is the distance between the player and the enemy
    float zombieScale;

    public float range;        // The range between the player and the enemy
    int hp;                   // The health of the enemy

    float timeToAttack = 0;   // Condition for attack

    bool dist;
    bool soundEffect;     // To make sure the sound effects play once at a time
    bool isAlive;
    bool inHit;
    bool isDead;

    GameObject hitPlayer;
    GameObject playerIsDead;

    public GameObject blood;
    GameObject bloodSound;

    // Animator
    Animator anm;

    // Sound Effects
    public AudioSource audioSource;
    public AudioClip idleSound;
    public AudioClip walkingSound;
    public AudioClip attackSound;
    public AudioClip deadSound;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        // Check where is the player position
        playerPos = GameObject.Find("Player").transform;
        playerScale = GameObject.Find("Player");
        range = 6.5f;
        dist = true;

        // Animations
        anm = GetComponent<Animator>();

        hp = 4;

        soundEffect = true;
        isAlive = true;

        hitPlayer = GameObject.Find("Player");
        playerIsDead = GameObject.Find("Player");

        bloodSound = GameObject.Find("ZombiesManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            playerDis = Vector2.Distance(transform.position, playerPos.position);  // Check what is the distance between the player and the enemy
            zombieScale = playerScale.transform.position.x;                       // Check what is the player scale

            if (playerDis > range && dist)     // Condition for idle position
            {
                anm.SetBool("isIdle", true);
                anm.SetBool("isWalk", false);
                anm.SetBool("isAttack", false);

                float i = range;
                i = 14;
                if (soundEffect && playerDis < i)
                {
                    audioSource.PlayOneShot(idleSound);
                    soundEffect = false;
                }

            }
            else if (playerDis < range && dist)       // When the player in range
            {
                anm.SetBool("isIdle", false);
                anm.SetBool("isWalk", true);
                anm.SetBool("isAttack", false);

                if (soundEffect == false)
                {
                    audioSource.PlayOneShot(walkingSound);
                    soundEffect = true;
                }

                if (zombieScale > transform.position.x)    // Check waht is the player scale
                {
                    transform.localScale = new Vector2(1, transform.localScale.y);
                    speed = 2.5f;
                    transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
                }
                else if (zombieScale < transform.position.x)
                {
                    transform.localScale = new Vector2(-1, transform.localScale.y);
                    speed = 2.5f;
                    transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
                }
            }

            if (playerDis < range && dist == false) // Condition for the zombie keep follow the player even if he start to attack
            {
                float i = range;

                i = 1;
                if (playerDis > i)
                {
                    dist = true;
                    Debug.Log("Run!!");
                }
            }

            if (dist == false)    // Condition for attack time (faster)
            {
                timeToAttack++;
                if (timeToAttack == 50)
                {
                    timeToAttack = 0;
                }
            }

            // Condition for attack
            if (dist == false)
            {
                anm.SetBool("isIdle", false);
                anm.SetBool("isWalk", false);
                anm.SetBool("isAttack", true);

                if (timeToAttack == 15)
                {
                    hitPlayer.GetComponent<PlayerEngine02>().playerLife -= 1;
                    audioSource.PlayOneShot(attackSound);
                    timeToAttack++;
                }

                if (zombieScale > transform.position.x)
                {
                    transform.localScale = new Vector2(1, transform.localScale.y);
                }
                else if (zombieScale < transform.position.x)
                {
                    transform.localScale = new Vector2(-1, transform.localScale.y);
                }
            }

            // When the enemy is dead
            if (hp == 0)
            {
                anm.SetTrigger("isDead");
                audioSource.PlayOneShot(deadSound);
                isAlive = false;
                Debug.Log("Kill!");
                inHit = false;
                isDead = true;
            }
        }
        // When the player is dead
        if (playerIsDead.GetComponent<PlayerEngine02>().playerAlive == false)
        {
            dist = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)         // If  zombie touch the player the condition for attack is possible
    { 
        if (collision.gameObject.tag == "Player" && isAlive)
        {
            dist = false;
            Debug.Log("Attack!");
        }

        // If the enemy is dead and the player touch on the enemy, destroy the enemy
        if (isDead && collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bullet" && isAlive)
        {
            hp--;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(hitSound);
        }
        else if (collision.gameObject.tag == "Bullet")            // If the zombie is dead and the player keep shooting (create blood effect)
        {
            bloodSound.GetComponent<ZombiesManager>().BloodSound();
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(blood, new Vector3(transform.position.x, transform.position.y - 0.5f, 0), blood.transform.rotation);
        }
    }

}
