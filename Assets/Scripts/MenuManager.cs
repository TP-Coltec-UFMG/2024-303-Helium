using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject optionsMenu;
    private GameObject creditsMenu;
    private GameObject colorBlindnessMenu;
    
    void Start()
    {
        mainMenu = transform.Find("MainMenu").gameObject;
        optionsMenu  = transform.Find("OptionsMenu").gameObject;
        creditsMenu = transform.Find("CreditsMenu").gameObject;
        colorBlindnessMenu = transform.Find("ColorBlindnessMenu").gameObject;
    }
    public void PressStart()
    {
        Debug.Log("Play signaled");
        // SceneManager.LoadScene("");
    }
    /* Sistema de toggle (alternar os valores de qual menu está aberto) */
    public void OpenOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
    public void OpenColorBlindnessMenu()
    {
        optionsMenu.SetActive(false);
        colorBlindnessMenu.SetActive(true);
    }
    public void Back_ToMenu()
    {
        optionsMenu.SetActive(false); creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void Back_ToOptions()
    {
        colorBlindnessMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Debug.Log("Exit signaled");
        Application.Quit();
    }
}
