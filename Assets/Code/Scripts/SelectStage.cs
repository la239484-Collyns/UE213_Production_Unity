using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class StartStage : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene()
    {
        SceneManager.LoadScene("Road");
        Debug.Log("Hello");
    }

    public void endGame()
    {
        Application.Quit();
    }
    public void RetryLevel(string sceneName)
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(sceneName);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;

    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
