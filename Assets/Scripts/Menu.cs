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

    // ���¿�ʼ��Ϸ�ĺ���
    void RestartGame()
    {
        SceneManager.LoadScene("PlaneWars");
    }

    // �˳���Ϸ�ĺ���
    void QuitGame()
    {
        Application.Quit();
    }
}
