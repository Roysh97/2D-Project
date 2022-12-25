using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEngine02 : MonoBehaviour
{
    float xmovement;           // Movment
    float playerScalex;
    float speed;

    float numShoot;     //number of time the player can shoot
    float countdownToShoot;

    public GameObject reloadSignR;
    public int coinsAdded;
    GameObject coinsNumber;

    GameObject escObject;

    Rigidbody2D Rb;
    Animator animate;

    int isJumping = 0;      // Condition for double jump
    bool isBulletDir;
    bool isCanShoot;
 
    public GameObject ZombieTrigger;

    public int playerLife;
    bool isHealthfull;
    public bool playerAlive;
    public bool isCanMove;
    float localScale;

    public GameObject Bullet;
    public GameObject AcidDeath;

    bool isDamage;
                                                                                         //Prefab Heart1 //Prefab Heart2 //Prefab Heart3 //Prefab Heart4
    public GameObject [] PlayerHeart;   // this value holds 4 Hearts of type gameobject        Heart 0          Heart 1        Heart 2        Heart 3
    public GameObject [] Bullets;         

    // Sound Effects
    public AudioSource soundManager;
    public AudioClip lifeSound;
    public AudioClip jumpingSound;
    public AudioClip hitZombie;
    public AudioClip shot;
    public AudioClip gameOverScene;
    public AudioClip RdGun;  // reload gun audio
    public AudioClip collectCoin;

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
        coinsAdded = 0;
        isCanMove = true;

        Debug.Log("PlayerLife" + playerLife);
        countdownToShoot = 10;
        isCanShoot = true;
        numShoot = 0;
        coinsNumber = GameObject.Find("CoinsCanvas");
        escObject = GameObject.Find("SceneManager");
    }

    // Update is called once per frame
    void Update()
    {
        playerScalex = transform.localScale.x;   // Player scale 

        // Condition for full health or just a part
        if (playerLife >= 4)
        {
            isHealthfull = true;
        }
        else if (playerLife <= 3)
        {
            isHealthfull = false;
        }

        if (playerAlive == true && isDamage == false)   // While player is alive he can move and play the anim
        {
            if(isCanMove)
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

                    isJumping++;                                  // isjumping gives the player the option to jump twice
                    soundManager.PlayOneShot(jumpingSound);
                }

                // Shot function

                if (countdownToShoot <= 0)
                {
                    reloadSignR.SetActive(true);
                    numShoot = 0;

                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        countdownToShoot = 10;
                        isCanShoot = true;
                        soundManager.PlayOneShot(RdGun);
                        reloadSignR.SetActive(false);
                        Bullets[5].gameObject.SetActive(true);
                        Bullets[4].gameObject.SetActive(true);
                        Bullets[3].gameObject.SetActive(true);
                        Bullets[2].gameObject.SetActive(true);
                        Bullets[1].gameObject.SetActive(true);
                        Bullets[0].gameObject.SetActive(true);
                    }
                }

                if (numShoot == 6)
                {
                    isCanShoot = false;
                    countdownToShoot -= Time.deltaTime;
                    Debug.Log(countdownToShoot -= Time.deltaTime);
                }

                if (isCanShoot == true && countdownToShoot == 10)
                {
                    if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        numShoot++;

                        if (playerScalex == 1.2f)
                        {
                            isBulletDir = true;
                        }
                        else if (playerScalex == -1.2f)
                        {
                            isBulletDir = false;
                        }

                        if (isBulletDir == true)
                        {
                            Instantiate(Bullet, new Vector3(transform.position.x + 0.7f, transform.position.y - 0.3f, 0), Bullet.transform.rotation);
                            soundManager.PlayOneShot(shot);
                        }
                        else if (isBulletDir == false)
                        {
                            Instantiate(Bullet, new Vector3(transform.position.x - 0.7f, transform.position.y - 0.3f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));   //Quaternion.Euler(new Vector3(0, 0, 180) makes the bullet turn around 180 degrees
                            soundManager.PlayOneShot(shot);
                        }
                    }
                }
            }

            if(escObject.GetComponent<EscGameButton>().escPanel.activeInHierarchy == true)
            {
                isCanMove = false;
            }
            else if (escObject.GetComponent<EscGameButton>().escPanel.activeInHierarchy == false)
            {
                isCanMove = true;
            }
        }

        if (numShoot == 6)
        {
            Bullets[0].gameObject.SetActive(false);
        }

        if (numShoot == 5)
        {
            Bullets[1].gameObject.SetActive(false);
        }
        else if (numShoot == 4)
        {
            Bullets[2].gameObject.SetActive(false);
        }
        else if (numShoot == 3)
        {
            Bullets[3].gameObject.SetActive(false);
        }
        else if (numShoot == 2)
        {
            Bullets[4].gameObject.SetActive(false);
        }
        else if (numShoot == 1)
        {
            Bullets[5].gameObject.SetActive(false);
        }

        // The condition for the life of the player and when the zombies attacks the player

        if (playerLife == 4)
        {
            Debug.Log("PlayerLife" + playerLife);
            PlayerHeart[3].gameObject.SetActive(true);
            PlayerHeart[2].gameObject.SetActive(true);
            PlayerHeart[1].gameObject.SetActive(true);
            PlayerHeart[0].gameObject.SetActive(true); // Destroy one heart from canvas
        }

        if (playerLife == 3)
        {
            Debug.Log("PlayerLife" + playerLife);
            PlayerHeart[3].gameObject.SetActive(false); // Destroy one heart from canvas
        }

        else if (playerLife == 2)
        {
            Debug.Log("PlayerLife" + playerLife);
            PlayerHeart[3].gameObject.SetActive(false);
            PlayerHeart[2].gameObject.SetActive(false);
        }

        else if (playerLife == 1)
        {
            Debug.Log("PlayerLife" + playerLife);
            PlayerHeart[3].gameObject.SetActive(false);
            PlayerHeart[2].gameObject.SetActive(false);
            PlayerHeart[1].gameObject.SetActive(false);
        }

        else if (playerLife == 0)                  // If all the hearts has been destroyed, kill the player and load the game over scene from the canvas
        {
            Debug.Log("PlayerLife" + playerLife);
            PlayerHeart[3].gameObject.SetActive(false);
            PlayerHeart[2].gameObject.SetActive(false);
            PlayerHeart[1].gameObject.SetActive(false);
            PlayerHeart[0].gameObject.SetActive(false);
            Debug.Log("Dead!!!");
            animate.SetTrigger("Dead");
            playerAlive = false;
            gameOver.SetActive(true);
            soundManager.PlayOneShot(gameOverScene);
            Rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "LevelEnd")
        {
            Rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

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
            playerLife += 1;               //every time a player collides with heart it refills one extra life for player

            if (playerLife == 4)            //  if playerLife = 4                                   
            {
                Debug.Log("PlayerLife" + playerLife);
                soundManager.PlayOneShot(lifeSound);
                PlayerHeart[3].gameObject.SetActive(true);
                Destroy(collision.gameObject);
            }
            else if (playerLife == 3)    //  if playerLife = 3                                                          
            {
                Debug.Log("PlayerLife" + playerLife);
                soundManager.PlayOneShot(lifeSound);
                PlayerHeart[2].gameObject.SetActive(true);
                Destroy(collision.gameObject);
            }
            else if (playerLife == 2)   //  if playerLife = 2 
            {
                Debug.Log("PlayerLife" + playerLife);
                soundManager.PlayOneShot(lifeSound);
                PlayerHeart[1].gameObject.SetActive(true);
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.tag == "Coin")    //adds number 1 each time we collide with Coin tag
        {
            soundManager.PlayOneShot(collectCoin);
            coinsNumber.GetComponent<CoinsNumber>().NumberofCoins++;             //adds one coin to the variable NumberofCoins in script CoinsNumber each time the player collides with Coin
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BigCoin")    //adds number 1 each time we collide with Coin tag
        {
            soundManager.PlayOneShot(collectCoin);
            coinsNumber.GetComponent<CoinsNumber>().NumberofCoins +=25;          //adds 25 coins to the variable NumberofCoins in script CoinsNumber each time the player collides with Coin
            Destroy(collision.gameObject);
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
    }
}
