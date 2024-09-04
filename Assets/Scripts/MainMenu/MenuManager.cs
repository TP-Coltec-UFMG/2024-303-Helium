using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;

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
        SceneManager.LoadScene("nivelJogar");
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
        // Função única para voltar para o menu inicial
        List<GameObject> menusToDisable = new List<GameObject>{optionsMenu, creditsMenu, colorBlindnessMenu};
        foreach (GameObject currentMenu in menusToDisable){
            currentMenu.SetActive(false);
        }

        mainMenu.SetActive(true);
    }
    public void Back_ToOptions()
    {
        // Função única para retornar às opções após acessar quaisquer itens de acessibilidade presentes nelas
        List<GameObject> menusToDisable = new List<GameObject>{colorBlindnessMenu};
        foreach (GameObject currentMenu in menusToDisable){
            currentMenu.SetActive(false);
        }

        optionsMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Debug.Log("Exit signaled");
        Application.Quit();
    }
}
