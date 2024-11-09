using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCube : MonoBehaviour
{
    [SerializeField] GameObject YellowBorder;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            if (YellowBorder != null){
                Destroy(YellowBorder);
            }

            Destroy(gameObject);
        }
    }
}
