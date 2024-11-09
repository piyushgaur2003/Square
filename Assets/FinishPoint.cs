using System;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] String levelName;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")){
            
            if (goNextLevel){
                SceneController.Instance.NextLevel();
            } else{
                SceneController.Instance.LoadScene(levelName);
            }
        }
    }
}
