using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberedSquare : MonoBehaviour
{
    [SerializeField] private int initialNumber = 2;
    private int currentNumber;
    public TextMeshProUGUI numberText;
    

    private static int totalPlatforms = 0;
    private static int platformsRemaining = 0;
    AudioManager audioManager;

    private void Awake()
    {
        GameObject audioObject = GameObject.FindWithTag("Audio");
        if (audioObject != null)
        {
            audioManager = audioObject.GetComponent<AudioManager>();
        }
        else
        {
            Debug.LogWarning("AudioManager not found in the scene.");
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        currentNumber = initialNumber;
        UpdateNumberText();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetPlatformCounts();
    }

    private void ResetPlatformCounts()
    {
        NumberedSquare[] allSquares = GameObject.FindObjectsOfType<NumberedSquare>();
        totalPlatforms = allSquares.Length;
        platformsRemaining = totalPlatforms;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentNumber--;

            if (currentNumber > 0)
            {
                audioManager.PlaySFX(audioManager.destroyObject);
                UpdateNumberText();
            }
            else
            {
                platformsRemaining--;
                audioManager.PlaySFX(audioManager.destroyObject);
                Destroy(gameObject, 0.3f);

                if (platformsRemaining == 0)
                {
                    LoadNextLevel();
                }
            }
        }
    }

    public void IncreaseNumber()
    {
        currentNumber++;
        UpdateNumberText();
    }

    public void DecreaseNumber()
    {
        currentNumber--;

        if (currentNumber <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            UpdateNumberText();
        }
    }

    private void UpdateNumberText()
    {
        if (numberText != null)
        {
            numberText.text = currentNumber.ToString();
        }
    }

    private void LoadNextLevel()
    {
        totalPlatforms = 0;
        platformsRemaining = 0;

        // Load the next level using SceneManager
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels to load.");
            SceneManager.LoadSceneAsync(0);
        }
    }
}
