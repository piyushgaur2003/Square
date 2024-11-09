using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 2.4f;
    private Rigidbody2D rb;
    public Transform groundCheck; 
    public float groundCheckRadius = 0.2f; 
    public LayerMask groundLayer; 
    private bool canJump = false;

    private bool isGrounded;
    AudioManager audioManager;

    private void Awake() {
        GameObject audioObject = GameObject.FindWithTag("Audio");
        if (audioObject != null)
        {
            audioManager = audioObject.GetComponent<AudioManager>();
        }
        else
        {
            Debug.LogWarning("AudioManager not found in the scene.");
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            audioManager.PlaySFX(audioManager.jump);
            Jump(-jumpForce);
        }
        else if (isGrounded && Input.GetKeyDown(KeyCode.RightArrow) ||Input.GetKeyDown(KeyCode.D))
        {
            audioManager.PlaySFX(audioManager.jump);
            Jump(jumpForce);
        }
    }

    void Jump(float direction)
    {
         rb.velocity = new Vector2(direction, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canJump = true;
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canJump = false;
        }
    }
}