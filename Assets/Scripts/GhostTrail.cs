using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrail : MonoBehaviour
{
    [SerializeField] GameObject ghostPrefab; 
    [SerializeField] float spawnInterval = 0.1f; 
    [SerializeField] float ghostLifetime = 0.5f;  
    [SerializeField] float fadeSpeed = 1.0f; 

    private SpriteRenderer playerSprite;

    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();

        StartCoroutine(SpawnGhosts());
    }

    private IEnumerator SpawnGhosts()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            GameObject ghost = Instantiate(ghostPrefab, transform.position, transform.rotation);

            SpriteRenderer ghostSprite = ghost.GetComponent<SpriteRenderer>();
            ghostSprite.sprite = playerSprite.sprite;

            StartCoroutine(FadeAndDestroyGhost(ghost));
        }
    }

    private IEnumerator FadeAndDestroyGhost(GameObject ghost)
    {
        SpriteRenderer ghostSprite = ghost.GetComponent<SpriteRenderer>();

        float fadeAmount = fadeSpeed * Time.deltaTime;

        while (ghostSprite.color.a > 0)
        {
            Color color = ghostSprite.color;
            color.a -= fadeAmount;
            ghostSprite.color = color;
            yield return null;
        }

        Destroy(ghost);
    }
}
