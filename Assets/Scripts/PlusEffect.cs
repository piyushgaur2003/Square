using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusEffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NumberedSquare[] allSquares = FindObjectsOfType<NumberedSquare>();
            foreach (var square in allSquares)
            {
                square.IncreaseNumber();
            }

            Destroy(gameObject);
        }
    }
}
