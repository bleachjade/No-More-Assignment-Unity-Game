using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharController : MonoBehaviour
{
    public float movementSpeed = 3f;
    public SpawnManager spawnManager;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hMovement = Input.GetAxis("Horizontal") * movementSpeed / 2;
        // Vector3 movingForward = Vector3.forward * movementSpeed;
        // float vMovement = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 movementDirection = new Vector3(hMovement, 0, movementSpeed) * Time.deltaTime;

        transform.Translate(movementDirection);

        if (movementDirection != Vector3.zero) {
            animator.SetBool("isMoving", true);
        }
        else {
            animator.SetBool("isMoving", false);
        }


    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "SpawnTrigger") {
            spawnManager.SpawnTriggerEntered();
        }
        else if (other.gameObject.tag == "ObstacleSpawnTrigger") {
            spawnManager.ObstacleSpawnTriggerEntered();
        }
        
        // if (other.gameObject.CompareTag("Obstacle")) {
        //     Destroy(gameObject);
        // }
    }
}
