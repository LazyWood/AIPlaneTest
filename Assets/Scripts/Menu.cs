using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button restartButton;
    public Button quitButton;
    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }


    void StartGame()
    {
        SceneManager.LoadScene("PlaneWars");
    }

    // 重新开始游戏的函数
    void RestartGame()
    {
        SceneManager.LoadScene("PlaneWars");
    }

    // 退出游戏的函数
    void QuitGame()
    {
        Application.Quit();
    }
}
