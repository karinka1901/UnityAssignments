using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void openMouseScene()
    {
        SceneManager.LoadScene(1);
    }

    public void openWASDScene()
    {
        SceneManager.LoadScene(2);
    }

    public void exitGame() 
    {
        Application.Quit();
    }

    public void backMenuScene()
    {
        SceneManager.LoadScene(0);
    }

}
