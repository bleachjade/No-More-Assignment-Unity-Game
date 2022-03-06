using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstacles;
    private float offset = 3.720388f;

    // Start is called before the first frame update
    void Start()
    {
        if(obstacles != null && obstacles.Count > 0) {
            Debug.Log("Before" + obstacles);
            obstacles = obstacles.OrderBy(r => r.transform.position.z).ToList();
            Debug.Log("After" + obstacles);
        }
    }

    public void MoveObstacle() {
        GameObject movedObstacle = obstacles[0];
        obstacles.Remove(movedObstacle);

        int rand = Random.Range(0, obstacles.Count);
        // movedObstacle = obstacles[rand];

        float newZ = obstacles[obstacles.Count - 1].transform.position.z + offset;
        movedObstacle.transform.position = new Vector3(-2.053518f, -4.845822f, newZ);
        obstacles.Add(movedObstacle);
    }
}
