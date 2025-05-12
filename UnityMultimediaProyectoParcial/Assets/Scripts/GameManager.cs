using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int playerCoins = 0;
    private GameObject player;
    public Text uiCoins; 
    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        if (uiCoins != null)
        {
            uiCoins.text = "Tarjetas: "+ playerCoins.ToString();
        }
    }

    public void CoinCollected()
    {   
        playerCoins++;
    }
}
