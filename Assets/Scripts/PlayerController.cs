using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public float movementSpeed = 3f;
    public float jumpForce = 400f;
    public float hMovement = 0.0f;
    public bool isDead = false;
    public AudioSource audioGameover;
    public AudioSource audioCollision;
    public AudioSource audioRunning;
    public LayerMask groundMask;

    // private bool isJumping

    public SpawnManager spawnManager;
    public NoMoreAssignmentManager gameManager;

    private Animator animator;
    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (!isDead) {
        //     Player_running();
        // }
    }

    public void Player_running() {

        // float hMovement = Input.GetAxis("Horizontal") * movementSpeed / 1.5f;

        // Vector3 movementDirection = new Vector3(hMovement, 0, movementSpeed) * Time.deltaTime;

        if (Input.touchCount > 0) {
            touch = Input.GetTouch(0);

            float touchMovement = touch.deltaPosition.x * movementSpeed / 1.5f;
            hMovement = Mathf.Clamp(touchMovement, -3, 3);
        }
        

        Vector3 movementDirection = new Vector3(hMovement, 0, movementSpeed) * Time.deltaTime;

        transform.Translate(movementDirection);

        animator.SetBool("isJumping", false);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }

        if (movementDirection != Vector3.zero) {
            animator.SetBool("isMoving", true);
            audioRunning.Play();
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
    }

    private void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.tag == "Obstacle") {
            audioCollision.Play();
            Debug.Log("HIT OBSTACLE!!");
            isDead = true;
            animator.SetBool("isMoving", false);
            gameManager.gameoverPanel.SetActive(true);
            audioGameover.Play();
            gameManager.onGameFinished.Invoke();
        }
    }

    void Jump() {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/2) + 0.1f, groundMask);

        

        if(isGrounded) {
            rb.AddForce(Vector3.up * jumpForce);
            animator.SetBool("isJumping", true);
            
        }
    }
}
