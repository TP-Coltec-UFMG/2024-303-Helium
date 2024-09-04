using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRefletores : MonoBehaviour{
    public GameObject objeto;
    private Vector3 newPosition;

    void OnMouseDown (){
        newPosition = new Vector3(100, 100, -1);

        // Verifica se o objeto que vai se clonado foi atribuído e o raio está parado
        if (objeto != null )
	{
	    //Logica para que não tenha mais de um refletor "selecionado"
	    if (GameObject.Find("hangedRefletor") != null)
	    {
		Destroy(GameObject.Find("hangedRefletor"));
	    }

	    var clone = Instantiate(objeto, newPosition, Quaternion.Euler(0, 0, 0));

	    Destroy(clone.GetComponent<ButtonRefletores>());

	    clone.GetComponent<Renderer>().enabled = false;
	    clone.name = $"hangedRefletor";
        }
    } 
}
