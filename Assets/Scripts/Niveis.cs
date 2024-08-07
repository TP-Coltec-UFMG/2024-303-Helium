using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveis : MonoBehaviour
{
    public string nivel;
    // Start is called before the first frame update
    public void acessarNivel(string nivel)
    {
        string scene = "Nivel" + nivel;
        SceneManager.LoadScene(scene);
    }
}
