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
}
