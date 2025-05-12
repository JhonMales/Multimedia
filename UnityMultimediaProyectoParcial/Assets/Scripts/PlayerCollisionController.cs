using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionController : MonoBehaviour
{
    public SpawnManager spawnManager;
    public GameManager gameManager;
    public PlayerMovement playerMovement;
    private int playerScore = 0; // Puntaje del jugador

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "SpawnTrigger")
        {
            spawnManager.SpawnEntered();
        }
        if(other.tag == "coin")
        {
            gameManager.CoinCollected();
            Destroy(other.gameObject);
        }
        if(other.tag == "Enemy")
        {
            SceneManager.LoadScene("gameOver");
        }
     
    }
}
