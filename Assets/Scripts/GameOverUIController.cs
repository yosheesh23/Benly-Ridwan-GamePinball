using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Button playGameButton;
    public Button mainMenuButton;
    public Button creditButton;

    private void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenu);
        playGameButton.onClick.AddListener(PlayGame);
        creditButton.onClick.AddListener(Credit);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Pinball");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
}