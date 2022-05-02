using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEngine02 : MonoBehaviour
{
    float xmovement;           // Movment
    float playerScalex;
    float speed;

    Rigidbody2D Rb;
    Animator animate;

    int isJumping = 0;      // Condition for double jump
    bool isBulletDir;

    public GameObject ZombieTrigger;

    public int playerLife;
    bool isHealthfull;
    public bool playerAlive;
    float localScale;

    public GameObject Bullet;

    public GameObject AcidDeath;

    bool isDamage;
                                                                                         //Prefab Heart1 //Prefab Heart2 //Prefab Heart3 //Prefab Heart4
    public GameObject[] PlayerHeart;   // this value holds 4 Hearts of type gameobject        Heart 0          Heart 1        Heart 2        Heart 3

    // Sound Effects
    public AudioSource soundManager;
    public AudioClip jumpingSound;
    public AudioClip hitZombie;
    public AudioClip shot;
    public AudioClip gameOverScene;

    public GameObject gameOver;      // Game over Scene (canvas)

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();

        speed = 3f;

        playerLife = 4;
        playerAlive = true;
        isHealthfull = true;
        isDamage = false;

        Debug.Log("PlayerLife" + playerLife);
    }

    // Update is called once per frame
    void Update()
    {
        playerScalex = transform.localScale.x;   // Player scale 

        //  Condition for full health or just a part
        if (playerLife == 4)
        {
            isHealthfull = true;
        }
        else if (playerLife == 3 || playerLife == 2 || playerLife == 1)
        {
            isHealthfull = false;
        }

        if (playerAlive == true && isDamage == false)   // While player is alive he can move and play the anim
        { 
             xmovement = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
             transform.Translate(xmovement, 0, 0);
            

            if (xmovement == 0)
            {
                animate.SetBool("isidle", true);
                animate.SetBool("iswalk", false);
                animate.SetBool("isrun", false);
            }
            else if (xmovement > 0)
            {
                speed = 3f;
                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                animate.SetBool("iswalk", true);
                animate.SetBool("isrun", false);
                animate.SetBool("isidle", false);
            }
            else if (xmovement < 0)
            {
                speed = 3f;
                transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
                animate.SetBool("iswalk", true);
                animate.SetBool("isrun", false);
                animate.SetBool("isidle", false);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (xmovement > 0)
                {
                    speed = 5f;
                    transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                    animate.SetBool("isrun", true);
                    animate.SetBool("iswalk", false);
                    animate.SetBool("isidle", false);
                }

                else if (xmovement < 0)
                {
                    speed = 5f;
                    transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
                    animate.SetBool("isrun", true);
                    animate.SetBool("iswalk", false);
                    animate.SetBool("isidle", false);
                }
            }

            if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.Space)))
            {
                animate.SetBool("isrun", false);
                animate.SetBool("isjump", true);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isJumping <= 1)
            {
                Rb.AddForce(new Vector2(0, 250));
                animate.SetBool("iswalk", false);
                animate.SetBool("isidle", false);
                animate.SetBool("isjump", true);

                isJumping++;                                              // isjumping gives the player the option to jump twice
                soundManager.PlayOneShot(jumpingSound);
            }

            // Shot function
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Mouse0)) 
            {

                if(playerScalex == 1.2f)
                {
                    isBulletDir = true;
                }
                else if (playerScalex == -1.2f)
                {
                    isBulletDir = false;
                }

                if (isBulletDir == true)
                {
                    Instantiate(Bullet, new Vector3(transform.position.x + 0.7f, transform.position.y - 0.3f, 0) , Bullet.transform.rotation);
                    soundManager.PlayOneShot(shot);
                }
                else if (isBulletDir == false)
                {
                    Instantiate(Bullet, new Vector3(transform.position.x - 0.7f, transform.position.y - 0.3f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));   //Quaternion.Euler(new Vector3(0, 0, 180) makes the bullet turn around 180 degrees
                    soundManager.PlayOneShot(shot);
                }
            }

            // The condition for life when the zombies attack the player
            if (playerLife == 3)
            {
                Debug.Log("PlayerLife" + playerLife);
                PlayerHeart[3].gameObject.SetActive(false); // Destroy one heart from canvas
            }

            else if (playerLife == 2)
            {
                Debug.Log("PlayerLife" + playerLife);
                PlayerHeart[2].gameObject.SetActive(false); 
            }

            else if (playerLife == 1)
            {
                Debug.Log("PlayerLife" + playerLife);
                PlayerHeart[1].gameObject.SetActive(false);
            }

            else if (playerLife == 0)                  // If all the hearts has been destroyed, kill the player and load the game over scene from the canvas
            {
                Debug.Log("PlayerLife" + playerLife);
                PlayerHeart[0].gameObject.SetActive(false);
                Debug.Log("Dead!!!");
                animate.SetTrigger("Dead");
                playerAlive = false;
                gameOver.SetActive(true);
                soundManager.PlayOneShot(gameOverScene);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Acid")         // If the player fall down to the acid, kill him immediately
        {
            playerLife -= 4;

            if (playerLife > 0)                                 //when life hearts is either 4 , 3 , 2 , 1
            {
                PlayerHeart[3].gameObject.SetActive(false);
                PlayerHeart[2].gameObject.SetActive(false);
                PlayerHeart[1].gameObject.SetActive(false);
                PlayerHeart[0].gameObject.SetActive(false);
                Debug.Log(playerLife);
            }
            else if (playerLife <= 0)      //here is when the player dies if playerLife is either -3 , -2 , -1 , 0   
            {
                PlayerHeart[3].gameObject.SetActive(false);
                PlayerHeart[2].gameObject.SetActive(false);
                PlayerHeart[1].gameObject.SetActive(false);
                PlayerHeart[0].gameObject.SetActive(false);
                Instantiate(AcidDeath, new Vector3(transform.position.x, transform.position.y - 1, 0), AcidDeath.transform.rotation);
                playerAlive = false;
                gameOver.SetActive(true);
                gameObject.SetActive(false);
                soundManager.PlayOneShot(gameOverScene);
            }
        }

        if (collision.gameObject.tag == "Saw") // If the player hit the saw he lose 3 hearts 
        {
            localScale = transform.localScale.x;

            playerLife -= 3;

            if (playerLife > 0)                  //when life hearts is either 4 , 3 , 2 , 1
            {
                if (localScale == 1.2f)
                {
                    PlayerHeart[3].gameObject.SetActive(false);
                    PlayerHeart[2].gameObject.SetActive(false);
                    PlayerHeart[1].gameObject.SetActive(false);
                    Debug.Log("PlayerLife" + playerLife);
                    Rb.AddForce(new Vector2(-150, 200));  // throw away the player when he hit the saw
                    isDamage = true;

                }
                else if (localScale == -1.2f)
                {
                    PlayerHeart[3].gameObject.SetActive(false);
                    PlayerHeart[2].gameObject.SetActive(false);
                    PlayerHeart[1].gameObject.SetActive(false);
                    Debug.Log("PlayerLife" + playerLife);
                    Rb.AddForce(new Vector2(150, 200));
                    isDamage = true;
                }
            }
            else if (playerLife <= 0)              //here is when the player dies if playerLife is either -3 , -2 , -1 , 0    
            {
                Debug.Log(playerLife);
                PlayerHeart[3].gameObject.SetActive(false);
                PlayerHeart[2].gameObject.SetActive(false);
                PlayerHeart[1].gameObject.SetActive(false);
                PlayerHeart[0].gameObject.SetActive(false);
                animate.SetTrigger("Dead");
                playerAlive = false;
                gameOver.SetActive(true);
                soundManager.PlayOneShot(gameOverScene);
            }
        }

        if (collision.gameObject.tag == "Spike")    // If the player hit the spike he lose 2 hearts
        {
            localScale = transform.localScale.x;

            playerLife -= 2;

             if (playerLife == 2)
            {
                if (localScale == 1.2f)
                {
                    PlayerHeart[3].gameObject.SetActive(false);
                    PlayerHeart[2].gameObject.SetActive(false);
                    Debug.Log("PlayerLife" + playerLife);
                    Rb.AddForce(new Vector2(-150, 200));    // throw away the player when he hit the spike
                    isDamage = true;
                }
                else if (localScale == -1.2f)
                {
                    PlayerHeart[3].gameObject.SetActive(false);
                    PlayerHeart[2].gameObject.SetActive(false);
                    Debug.Log("PlayerLife" + playerLife);
                    Rb.AddForce(new Vector2(150, 200));
                    isDamage = true;
                }
            }
            else if (playerLife == 1)
            {
                if (localScale == 1.2f)
                {
                    PlayerHeart[3].gameObject.SetActive(false);
                    PlayerHeart[2].gameObject.SetActive(false);
                    PlayerHeart[1].gameObject.SetActive(false);
                    Debug.Log("PlayerLife" + playerLife);
                    Rb.AddForce(new Vector2(-150, 200));
                    isDamage = true;
                }
                else if (localScale == -1.2f)
                {
                    PlayerHeart[3].gameObject.SetActive(false);
                    PlayerHeart[2].gameObject.SetActive(false);
                    PlayerHeart[1].gameObject.SetActive(false);
                    Debug.Log("PlayerLife" + playerLife);
                    Rb.AddForce(new Vector2(150, 200));
                    isDamage = true;
                }
            }
            else if (playerLife <= 0)
            {
                PlayerHeart[1].gameObject.SetActive(false);
                PlayerHeart[0].gameObject.SetActive(false);
                Debug.Log("Dead");
                animate.SetTrigger("Dead");
                playerAlive = false;
                gameOver.SetActive(true);
                soundManager.PlayOneShot(gameOverScene);
            }
        }

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Zombie01")
        {
            isJumping = 0;                              // Reset jumping condition
            animate.SetBool("isjump", false);
            animate.SetBool("isidle", true);
            isDamage = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart" && isHealthfull == false)
        {
            playerLife += 1;               //playerLife != because if the zombie attacks twich or three times in a row and then the player takes only 1 heart its refilling all the hearts at once

            if (playerLife > 3)                                  //  if playerLife =4 bigger than 3                                    
            {
                Debug.Log("PlayerLife" + playerLife);
                PlayerHeart[3].gameObject.SetActive(true);
                Destroy(collision.gameObject);

            }
            else if (playerLife > 2 && playerLife != 4)    //  if playerLife = 3 bigger than 2  *is playerLife =4 bigger than 3*(it's supposed to be 4) but the code says that dont ! be equal to 4                                                         
            {
                Debug.Log("PlayerLife" + playerLife);
                PlayerHeart[2].gameObject.SetActive(true);
                Destroy(collision.gameObject);

            }
            else if (playerLife >= 1 && playerLife != 3)
            {
                Debug.Log("PlayerLife" + playerLife);         //  if playerLife = 2 bigger than 1  *is playerLife =3 bigger than 2* (it's supposed to be 3) but the code says that dont ! be equal to 3
                PlayerHeart[1].gameObject.SetActive(true);
                Destroy(collision.gameObject);

            }

        }

        // All the zombies trigger on level01
        if (collision.gameObject.tag == "TwoZombiesTrigger")
        {
            ZombieTrigger.GetComponent<ZombiesManager>().TwoZombiesTrigger();
            Destroy(collision.gameObject);
            Debug.Log("Hello Zombies!");
        }
        else if (collision.gameObject.tag == "ZombieTrigger")
        {
            ZombieTrigger.GetComponent<ZombiesManager>().ZombieTrigger();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "MultiZombiesTriggerR")
        {
            ZombieTrigger.GetComponent<ZombiesManager>().MultiZombiesTriggerR();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "MultiZombiesTrigger2")
        {
            ZombieTrigger.GetComponent<ZombiesManager>().MultiZombiesTrigger2();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "MultiZombiesTrigger3")
        {
            ZombieTrigger.GetComponent<ZombiesManager>().MultiZombiesTrigger3();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "MultiZombiesTrigger4")
        {
            ZombieTrigger.GetComponent<ZombiesManager>().MultiZombiesTrigger4();
            Destroy(collision.gameObject);
        }
    }
}
