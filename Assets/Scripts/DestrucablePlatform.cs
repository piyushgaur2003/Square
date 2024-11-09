using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrucablePlatform : MonoBehaviour
{
    [SerializeField] GameObject destroyEffect; 
    [SerializeField] float playerDelay = 1f;
    [SerializeField] float jumpForce = 4.3f;
    [SerializeField] int platformValue = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.PlatformDestroyed(platformValue);

            GetComponent<SpriteRenderer> ().enabled = false;
    
            if (destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject, 0.7f); 
        }
    }

}
