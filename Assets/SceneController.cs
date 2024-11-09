using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    private void Awake() {
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public void NextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels to load. Returning to the first scene.");
            SceneManager.LoadSceneAsync(0); 
        }
    }
    public void LoadScene(String sceneName){
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
        else
        {
            Debug.LogError("Invalid scene name provided.");
        }
    }
}
