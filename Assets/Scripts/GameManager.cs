using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isGameOver = false;

 
    void Awake()
    {
        Instance = this;
    }



    public void GameOver()
    {
        //Time.timeScale = 0;
        SceneManager.LoadScene("Menu");
    }
}
