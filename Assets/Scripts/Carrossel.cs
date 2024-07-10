using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrossel : MonoBehaviour
{
    [SerializeField]
    private float velocidade;

    private Vector3 posicaoInicial;
    private float tamanhoRealDaImagem;
    private void Awake()
    {
        this.posicaoInicial = this.transform.position;
        float tamanhoDaImagem = this.GetComponent<SpriteRenderer>().size.x;
        float escala = this.transform.localScale.x;
        this.tamanhoRealDaImagem = tamanhoDaImagem * escala;
    }
    private void Update()
    {
        // x = v0t * imagem.x;
        float deslocamento = Mathf.Repeat(this.velocidade * Time.deltaTime, this.tamanhoRealDaImagem);
        // Objeto.x = x0 + x;
        this.transform.position = this.posicaoInicial + Vector3.left * deslocamento;
    }
}
