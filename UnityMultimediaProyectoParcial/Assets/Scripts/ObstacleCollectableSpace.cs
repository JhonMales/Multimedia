using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollectableSpace : MonoBehaviour
{   
    public List<float> collectableLanesX;
    public List<float> collectablesJumpsX;

    void Start()
    {

    }
    void Update()
    {
        
    }
    public float GetLane()
    {
        if(collectableLanesX == null || collectableLanesX.Count < 1)
        {
            return -30f;
        }
        return collectableLanesX[Random.Range(0, collectableLanesX.Count)];
    }
    public float GetJump()
    {
        if(collectablesJumpsX == null || collectablesJumpsX.Count < 1)
        {
            return -30f;
        }
        return collectablesJumpsX[Random.Range(0, collectablesJumpsX.Count)];
    }

}
