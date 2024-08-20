using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefletorController : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;

    void OnMouseDown (){
        Debug.Log("OnMouseDown");
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Calcula offset entre a posição do mouse e a posição do objeto
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private Vector3 GetMouseWorldPosition(){
        // Pega a posição do mouse na tela e converte para coordenadas de mundo
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag (){
        // Atualiza a posição do objeto baseado na posição do mouse
        transform.position = GetMouseWorldPosition() + offset;
    }
}
