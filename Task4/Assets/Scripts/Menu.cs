using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;
    public bool isMenuOpen = false;


    void Start()
    {
        menuPanel.SetActive(isMenuOpen);
    }



    public void controlMenu()
    {
        isMenuOpen = !isMenuOpen;
        menuPanel.SetActive(isMenuOpen);
       
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void Exit()
    {
        Application.Quit();

    }
}
