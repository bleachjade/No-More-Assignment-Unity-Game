using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadSpawner roadSpawner;
    ObstacleSpawner obstacleSpawner;

    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        obstacleSpawner = GetComponent<ObstacleSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTriggerEntered() {
        roadSpawner.MoveRoad();
    }

    public void ObstacleSpawnTriggerEntered() {
        obstacleSpawner.MoveObstacle();
    }

}
