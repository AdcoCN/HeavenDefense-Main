using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameSceneName = "GameScene";
    public string optionsSceneName = "OptionsScene";





    public void GameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OptionsScene()
    {
        SceneManager.LoadScene(optionsSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // volver al menú principal desde GameScene
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadMainMenuOnClick()
    {
        BackToMainMenu();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == gameSceneName && Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMainMenu();
        }
    }
}
