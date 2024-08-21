using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneRefletores : MonoBehaviour{
    public GameObject objeto;
    private Vector3 newPosition;
    private Vector3 mousePos;

    void onMouseDrag()
    {
        if(objeto != null){
            GameObject clone = Instantiate(objeto, mousePos, Quaternion.Euler(0, 0, 0));

            Destroy(clone.GetComponent<CloneRefletores>()); // Impede que o objeto clonado seja clonável
        }
    }
    void OnMouseDown (){
        newPosition = new Vector3(0, 0, -1);

        // Verifica se o objeto que vai se clonado foi atribuído
        if (objeto != null){
            // Clona o objeto e posiona na nova posição
            GameObject clone = Instantiate(objeto, newPosition, Quaternion.Euler(0, 0, 0));
            
            Destroy(clone.GetComponent<CloneRefletores>());

            clone.AddComponent<RefletorController>();
        }
    } 
}
