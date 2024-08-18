using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveis : MonoBehaviour
{
    public void acessarNivel(string nivel)
    {
        string scene = "nivel " + nivel;
        SceneManager.LoadScene(scene);
    }
}
