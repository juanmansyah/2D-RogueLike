using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame ()
    {
        Debug.Log("program quit");
        Application.Quit();  
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
}
