using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadSpawner roadSpawner;
    PlotSpawner plotSpawner;
    ObstacleSpawner obstacleSpawner;

    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        plotSpawner = GetComponent<PlotSpawner>();
        obstacleSpawner = GetComponent<ObstacleSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEntered()
    {
        roadSpawner.MoveRoad();
        plotSpawner.SpawnPlot();
        obstacleSpawner.SpawnObstacles();
    }
}
