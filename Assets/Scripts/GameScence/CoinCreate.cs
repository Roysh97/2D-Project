 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreate : MonoBehaviour
{
    public GameObject Coin;
    public GameObject BigCoin;

    int howMuch;

    int i;
    float disX, disX2, disX3, disX4, disX5;         //distance from each coin in fuction CreateXCoins
    float disxMoreCoins, disxMoreCoins2, disxMoreCoins3, disxMoreCoins4;      //distance from each coin in fuction CreateXCoins2
    float disY , disY2;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateXCoins();
    }

    // Call function at start game. Create coins all over part one of the map.
    public void CreateXCoins()
    {
       i = 0;
       howMuch = 6;

        while (i < howMuch)
        {
            Instantiate(Coin, new Vector3(0 + disX, -1.38f, 0), Coin.transform.rotation);

            disX += 2;

            i++;
        }

        i = 0;
        howMuch = 5;

        while (i < howMuch)
        {
            Instantiate(Coin, new Vector3(18 + disX2, -1.38f, 0), Coin.transform.rotation);

            disX2 += 2;

            i++;
        }

        i = 0;
        howMuch = 4;

        while (i < howMuch)
        {
            Instantiate(Coin, new Vector3(28 + disX3, 0.38f + disY, 0), Coin.transform.rotation);

            disX3 += 1;
            disY += 1;

            i++;
        }

       
        i = 0;
        howMuch = 11;

        while (i < howMuch)
        {
            Instantiate(Coin, new Vector3(-11 + disX4, -7, 0), Coin.transform.rotation);
            
            disX4 += 2;
            disY += 2;

            i++;
        }

        i = 0;
        howMuch = 7;

        while (i < howMuch)
        {
            Instantiate(Coin, new Vector3(-17f, -7f + disY2, 0), Coin.transform.rotation);

            disX4 += 2;
            disY2 -= 2;

            i++;
        }

        i = 0;
        howMuch = 12;

       while (i < howMuch)
       {
          Instantiate(Coin, new Vector3(-8f + disX5, -20f, 0), Coin.transform.rotation);

          disX5 += 3;

          i++;
       }
    }

    //Create more coins function
    public void CreateXCoins2()
    {
        i = 0;
        howMuch = 7;

        while (i < howMuch)
        {
            Instantiate(Coin, new Vector3(93 + disxMoreCoins, -61.2f, 0), Coin.transform.rotation);
            disxMoreCoins += 2;

            i++;
        }

        i = 0;
        howMuch = 3;

        while (i < howMuch)
        {
            Instantiate(Coin, new Vector3(112 + disxMoreCoins2, -61.2f, 0), Coin.transform.rotation);
            disxMoreCoins2 += 2;

            i++;
        }

        i = 0;
        howMuch = 10;

        while (i < howMuch)
        {
            Instantiate(Coin, new Vector3(98 + disxMoreCoins3, -56.36f, 0), Coin.transform.rotation);
            disxMoreCoins3 += 2;

            i++;
        }

        i = 0;
        howMuch = 10;

        while (i < howMuch)
        {
            Instantiate(Coin, new Vector3(146 + disxMoreCoins4, -60.85f, 0), Coin.transform.rotation);
            disxMoreCoins4 += 2;

            i++;
        }

        i = 0;
        howMuch = 1;

        while (i < howMuch)
        {
            Instantiate(BigCoin, new Vector3(224 , -52, 0), BigCoin.transform.rotation);
            
            i++;
        }
    }

    //Create More coins when player collides with the edge collider of CoinManager and get to the second part of the map
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CreateXCoins2();
            Debug.Log("More Coins!");
        }
    }
}
