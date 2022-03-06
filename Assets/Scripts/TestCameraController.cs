using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraController : MonoBehaviour
{
    private Transform player;

    private float xOffset = 2.499f;
    private float yOffset = 1.539f;
    private float zOffset = -2.16f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + xOffset, player.position.y + yOffset, player.position.z + zOffset);
    }
}
