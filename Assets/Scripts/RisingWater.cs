using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RisingWater : MonoBehaviour
{
    [SerializeField] private float riseSpeed = 0.1f; 
    [SerializeField] private float maxScaleY = 10f;
    [SerializeField] private float waitTimeForRestart = 0.5f;


    private Vector3 initialScale;

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


    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        if (transform.localScale.y < maxScaleY)
        {
             transform.localScale += new Vector3(0, riseSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SpriteRenderer> ().enabled = false;

            audioManager.PlaySFX(audioManager.destroyPlayer);
            StartCoroutine(RestartGame(waitTimeForRestart));
        }
    }

    private IEnumerator RestartGame(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

//     private void RestartGame1()
//     {
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

// //    // Option 1: Reload the current scene
// //         // UnityEngine.SceneManagement.SceneManager.LoadScene(
// //         //     UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);

// //         // Option 2: Reset the water scale
// //         transform.localScale = initialScale;

// //         // Reset player position and other game state as needed
// //         // Example: Find the player and reset its position
// //         GameObject player = GameObject.FindGameObjectWithTag("Player");
// //         if (player != null)
// //         {
// //             player.transform.position = new Vector3(0, 0, 0); // Set to starting position
// //         }
// //     }
//    }
}
