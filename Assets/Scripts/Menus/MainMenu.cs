using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Tags;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(((int)SceneIndex.GAME_SCENE));
    }

    public void OptionsMenu()
    {
        Debug.Log("OPTIONS MENU TO BE OPENED");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
