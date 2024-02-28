using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Pinball");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
