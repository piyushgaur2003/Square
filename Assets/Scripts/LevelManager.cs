using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    private int totalPlatforms; 
    private int platformsRemaining; 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        totalPlatforms = GameObject.FindObjectsOfType<DestrucablePlatform>().Length;
        platformsRemaining = totalPlatforms;
    }

    public void PlatformDestroyed(int platformValue)
    {
        platformsRemaining--;

        if (platformValue == 1 && platformsRemaining == 0)
        {
            SceneController.Instance.NextLevel();
        }
    }
}
