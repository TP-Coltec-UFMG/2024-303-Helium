using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamController : MonoBehaviour
{
    public Transform target;  // O alvo para onde o feixe de luz será direcionado
    private LineRenderer lineRenderer;
    public float moveSpeed = 3f;
    public Transform posInicial;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // if (lineRenderer == null)
        // {
        //     Debug.LogError("LineRenderer não encontrado neste GameObject. Verifique se o componente está anexado.");
        //     enabled = false; // Desativa este script para evitar erros adicionais
        // }else{
        //     Debug.Log("lineRenderer encontrado");
        // }
    }

    void Update()
    {
        // if (lineRenderer == null){
        //     Debug.LogError("Line Rendeer está nulo");
        //     return;
        // }

        // Debug.Log("entrou");
        // // Atualiza a posição final do feixe de luz para o alvo
        // lineRenderer.SetPosition(0, transform.position);
        // Debug.Log(transform.position);

        // if (target != null)
        // {
        //     lineRenderer.SetPosition(1, target.position);
        //     Debug.Log(target.position);
        // }
        // else
        // {
        //     lineRenderer.SetPosition(1, transform.position + transform.forward * 10);
        // }

        // Movimento com setas do teclado
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, moveY, 0);

        // Atualiza a posição do feixe de luz
        lineRenderer.SetPosition(0, posInicial.position);
        lineRenderer.SetPosition(1, transform.position);
    }
}
