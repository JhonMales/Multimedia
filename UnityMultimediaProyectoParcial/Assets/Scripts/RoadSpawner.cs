using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 93f;

    // Start is called before the first frame update
    void Start()
    {
        if(roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }  
    }
    // Update is called once per frame
    public void MoveRoad()
    {
        GameObject moveRoad = roads[0];
        roads.Remove(moveRoad); 
        float newZ = roads[roads.Count - 1 ].transform.position.z + offset;
        
        moveRoad.transform.position = new Vector3(0,0,newZ);
        roads.Add(moveRoad);
    }
}
