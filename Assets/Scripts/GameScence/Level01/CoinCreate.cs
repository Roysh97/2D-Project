using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreate : MonoBehaviour
{
    public GameObject Coin;

    int howMuch;

   //public float Dis;

    int i;
    float disX;
    float disY;
    float disNumX;
    float disNumY;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        disNumX = 5;
        howMuch = 8;

        CreateXCoins();

    }

    // Call function at start game. Create coins all over part one of the map.
    public void CreateXCoins()
    {
        while (i < howMuch)
        {
            Instantiate(Coin, new Vector3(-10 + disX, -16.84f, 0), Coin.transform.rotation);
            Instantiate(Coin, new Vector3(-10 + disX, -20.69f, 0), Coin.transform.rotation);
            disX += disNumX;

            i++;
        }

        i = 0;
        disX = 0;
        howMuch = 8;

        while (i < howMuch)
        {
            Instantiate(Coin, new Vector3(0 + disX, -1.38f, 0), Coin.transform.rotation);
            Instantiate(Coin, new Vector3(-13 + disX, -7.21f, 0), Coin.transform.rotation);
            disX += disNumX;

            i++;
        }

        i = 0;
        disX = 0;
        howMuch = 4;

        while (i < howMuch)
        {
            disNumX = 1;
            disNumY = 1;
            Instantiate(Coin, new Vector3(28.63f + disX, -1.38f + disY, 0), Coin.transform.rotation);
            disX += disNumX;
            disY += disNumY;

            i++;
        }

        i = 0;
        disX = 0;
        howMuch = 4;

        while (i < howMuch)
        {
            disNumY = 3f;
            Instantiate(Coin, new Vector3(-13f, -6.25f - disY, 0), Coin.transform.rotation);
            disY += disNumY;

            i++;
        }

        i = 0;
        disX = 0;
        howMuch = 8;

        while (i < howMuch)
        {
            disNumX = 3;
            Instantiate(Coin, new Vector3(33.7f + disX, -21.3f, 0), Coin.transform.rotation);
            disX += disNumY;

            i++;
        }


    }

    // Create coins when the player get to the second part of the map
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CreateXCoins2();
            Debug.Log("More Coins!");
        }
    }

    public void CreateXCoins2()
    {
        i = 0;
        disX = 0;
        howMuch = 7;

        while (i < howMuch)
        {
            disNumX = 6;
            Instantiate(Coin, new Vector3(69.24f + disX, -61.2f, 0), Coin.transform.rotation);
            disX += disNumX;

            i++;
        }

        i = 0;
        disX = 0;
        howMuch = 5;

        while (i < howMuch)
        {
            disNumX = 4.5f;
            Instantiate(Coin, new Vector3(93.63f + disX, -56.36f, 0), Coin.transform.rotation);
            disX += disNumX;

            i++;
        }

        i = 0;
        disX = 0;
        howMuch = 10;

        while (i < howMuch)
        {
            disNumX = 4f;
            Instantiate(Coin, new Vector3(135.2f + disX, -60.85f, 0), Coin.transform.rotation);
            disX += disNumX;

            i++;
        }

        i = 0;
        disX = 0;
        howMuch = 7;

        while (i < howMuch)
        {
            disNumX = 4.5f;
            Instantiate(Coin, new Vector3(213.07f + disX, -62.73f, 0), Coin.transform.rotation);
            disX += disNumX;

            i++;
        }
    }


}
