using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement;

public class botaoRetornar : MonoBehaviour
{

    void OnMouseDown()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Play signaled");
    }
}
