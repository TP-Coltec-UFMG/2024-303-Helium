using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Contador : MonoBehaviour
{
    public int valor;

    void Awake()
    {
	valor = 0;
    }

    public void subir()
    {
	valor+=1;
    }

    public void zerar()
    {
	valor = 0;
    }
}
