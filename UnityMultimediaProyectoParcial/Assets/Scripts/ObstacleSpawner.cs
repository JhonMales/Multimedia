using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{   
    private int initAmount = 7;
    private int spawnInterval = 93;
    private int lastSpawnZ = 10;
    private int spawnAmount = 7;

    public List<GameObject> obstacles;

    public GameObject Coins; 
    void Start()
    {
        for (int i = 0; i < initAmount; i++)
        {
            SpawnObstacles();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObstacles()
    {
        for(int i = 0; i < spawnAmount; i++)
        {
            lastSpawnZ += spawnInterval;

            if(Random.Range(0,1) == 0)
            {
                GameObject obstacle = obstacles[Random.Range(0, obstacles.Count)];

                Instantiate(obstacle, new Vector3(0, -0.18f, lastSpawnZ), obstacle.transform.rotation);

                if(Random.Range(0,2) == 1)
                {
                    ObstacleCollectableSpace space = obstacle.GetComponent<ObstacleCollectableSpace>();
                    Instantiate(Coins, new Vector3(space.GetLane(), 3, lastSpawnZ + 1.5f), Coins.transform.rotation);
                }
            }
            else 
            {
                if(Random.Range(0,2) == 1)
                {
                Instantiate(Coins, new Vector3(0, 3, lastSpawnZ + 1.5f), Coins.transform.rotation);
                }
            }
        }
    }



    /*public void SpawnObstacles()
    {
        for (int i = 1; i < SpawnAmount; i++)
        {
            lastSpawnZ += spawnInterval;
            GameObject obstacle = obstacles[Random.Range(0, obstacles.Count)];
            Instantiate(obstacle, new Vector3(0, 0.25f, lastSpawnZ), obstacle.transform.rotation);
        }
        
    }
    */
}