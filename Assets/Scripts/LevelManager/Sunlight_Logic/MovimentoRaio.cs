using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class movimento_do_raio : MonoBehaviour
{ 
    public LineRenderer lineRenderer;
    public float moveSpeed = 6f;
    public Vector3 posInicial;
    public Vector3 direcaoLuz;
    public GameObject contador;
    private Contador score;

    void Start()
    {
	lineRenderer = GetComponent<LineRenderer>();
	lineRenderer.startWidth = 0.4f;
	lineRenderer.endWidth = 0.4f;

	lineRenderer.SetPosition(0, posInicial);
	GetComponent<Transform>().position = posInicial;

	score = contador.GetComponent<Contador>();
    }

    void Update ()
    {
	float moveX = direcaoLuz.x * moveSpeed * Time.deltaTime;
	float moveY = direcaoLuz.y * moveSpeed * Time.deltaTime;
	transform.Translate(moveX, moveY, 0);

	// Atualiza a posição do feixe de luz
	lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
	Debug.Log("Buceta de game engine");

	if (collider.gameObject.tag == "gridTile")
	{
	    // Ignorar a colisão 
	    Debug.Log("Algo para fodase");
	    return;
	}
	else if (collider.gameObject.tag == "ref_up_right")
	{

	    if (direcaoLuz == Vector3.down)
	    {
		direcaoLuz = Vector3.right;
	    }
	    else if (direcaoLuz == Vector3.left)
	    {
		direcaoLuz = Vector3.up;
	    }
	    else
	    {
		direcaoLuz = Vector3.zero;
	    }
	}
	else if(collider.gameObject.tag == "ref_up_left")
	{
	    if (direcaoLuz == Vector3.down)
	    {
		direcaoLuz = Vector3.left;
	    }
	    else if (direcaoLuz == Vector3.right)
	    {
		direcaoLuz = Vector3.up;
	    }
	    else
	    {
		direcaoLuz = Vector3.zero;
	    }
	}
	else if(collider.gameObject.tag == "ref_down_right")
	{
	    if (direcaoLuz == Vector3.up)
	    {
		direcaoLuz = Vector3.right;
	    }
	    else if (direcaoLuz == Vector3.left)
	    {
		direcaoLuz = Vector3.down;
	    }
	    else
	    {
		direcaoLuz = Vector3.zero;
	    }
	}
	else if(collider.gameObject.tag == "ref_down_left")
	{
	    if (direcaoLuz == Vector3.up)
	    {
		direcaoLuz = Vector3.left;
	    }
	    else if (direcaoLuz == Vector3.right)
	    {
		direcaoLuz = Vector3.down;
	    }
	    else
	    {
		direcaoLuz = Vector3.zero;
	    }
	}
	else if(collider.gameObject.tag == "div_right_up_down")
	{
	    if (direcaoLuz == Vector3.left)
	    {
		clonarLuz(Vector3.up, collider.transform.position, collider);
		clonarLuz(Vector3.down, collider.transform.position, collider);
		direcaoLuz = Vector3.zero;
	    }
	    else if (direcaoLuz == Vector3.down)
	    {
		clonarLuz(Vector3.right, collider.transform.position, collider);
		clonarLuz(Vector3.down, collider.transform.position, collider);
		direcaoLuz = Vector3.zero;
	    }
	    else if (direcaoLuz == Vector3.up)
	    {
		clonarLuz(Vector3.right, collider.transform.position, collider);
		clonarLuz(Vector3.up, collider.transform.position, collider);
		direcaoLuz = Vector3.zero;
	    }
	    else
	    {
		direcaoLuz = Vector3.zero;
	    }
	}
	else if(collider.gameObject.tag == "div_down_right_left")
	{
	    if (direcaoLuz == Vector3.down)
	    {
		clonarLuz(Vector3.right, collider.transform.position, collider);
		clonarLuz(Vector3.left, collider.transform.position, collider);
		direcaoLuz = Vector3.zero;
	    }
	    else if (direcaoLuz == Vector3.left)
	    {
		clonarLuz(Vector3.left, collider.transform.position, collider);
		clonarLuz(Vector3.down, collider.transform.position, collider);
		direcaoLuz = Vector3.zero;
	    }
	    else if (direcaoLuz == Vector3.right)
	    {
		clonarLuz(Vector3.right, collider.transform.position, collider);
		clonarLuz(Vector3.down, collider.transform.position, collider);
		direcaoLuz = Vector3.zero;
	    }
	    else
	    {
		direcaoLuz = Vector3.zero;
	    }
	}
	else if(collider.gameObject.tag == "div_left_up_down")
	{
	    if (direcaoLuz == Vector3.right)
	    {
		clonarLuz(Vector3.up, collider.transform.position, collider);
		clonarLuz(Vector3.down, collider.transform.position, collider);
		direcaoLuz = Vector3.zero;
	    }
	    else if (direcaoLuz == Vector3.down)
	    {
		clonarLuz(Vector3.left, collider.transform.position, collider);
		clonarLuz(Vector3.down, collider.transform.position, collider);
		direcaoLuz = Vector3.zero;
	    }
	    else if (direcaoLuz == Vector3.up)
	    {
		clonarLuz(Vector3.left, collider.transform.position, collider);
		clonarLuz(Vector3.up, collider.transform.position, collider);
		direcaoLuz = Vector3.zero;
	    }
	    else
	    {
		direcaoLuz = Vector3.zero;
	    }
	}
	else if(collider.gameObject.tag == "div_up_right_left")
	{
	    if (direcaoLuz == Vector3.down)
	    {
		clonarLuz(Vector3.right, collider.transform.position, collider);
		clonarLuz(Vector3.left, collider.transform.position, collider);
		direcaoLuz = Vector3.zero;
	    }
	    else if (direcaoLuz == Vector3.left)
	    {
		clonarLuz(Vector3.left, collider.transform.position, collider);
		clonarLuz(Vector3.up, collider.transform.position, collider);
		direcaoLuz = Vector3.zero;
	    }
	    else if (direcaoLuz == Vector3.right)
	    {
		clonarLuz(Vector3.right, collider.transform.position, collider);
		clonarLuz(Vector3.up, collider.transform.position, collider);
		direcaoLuz = Vector3.zero;
	    }
	    else
	    {
		direcaoLuz = Vector3.zero;
	    }
	}
	else
	{
	    Debug.Log("Enfiei a pica na parede");
	    direcaoLuz = Vector3.zero;

	    if (collider.gameObject.name == "massan")
	    {
		score.subir();
		Debug.Log(score.valor);

		if(score.valor >= score.total)
		{
		    Debug.Log("Condição de vitoria atingida");
		}
	    }
	    return;
	}

	/*Explicação linha por linha desse pesadelo lovecraftiano:
	 * o objeto "raio de luz" e o raio de luz (linha) em si são duas coisas separadas, e não necessariamente 
	 * estão movendo junto. Esse código entre em ação apenas quando o objeto luz colide em modo TRIGGER
	 * com alg coisa (Colisão Rigid Body2D kinematic + Collider2D on Trigger), neste momento vamos divergir o
	 * caminho da luz, a posição final daquela seção é o mesmo que o objeto colidido, e o objeto é teletransportado
	 * para o objeto colidido também, dai começa um novo trecho de luz
	 */

	lineRenderer.SetPosition(lineRenderer.positionCount - 1, collider.transform.position);
	GetComponent<Transform>().position = collider.transform.position;
	lineRenderer.positionCount += 1;
    }

    public void clonarLuz(Vector3 dir, Vector3 posInicial, Collider2D collider)
    {
	var raioClone = Instantiate(gameObject, posInicial, Quaternion.identity);
	var Luz = raioClone.GetComponent<movimento_do_raio>();

	Luz.posInicial = posInicial;
	Luz.direcaoLuz = dir;
	Luz.lineRenderer.positionCount = 2;
	Vector3[] positions = {Luz.posInicial, Luz.posInicial};
	Luz.lineRenderer.SetPositions(positions);

	Physics2D.IgnoreCollision(collider, raioClone.GetComponent<Collider2D>());

	raioClone.name = "raioSolarClone";
    }
}
