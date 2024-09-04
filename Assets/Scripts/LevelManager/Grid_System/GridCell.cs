using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] private Color _rightColor, _wrongColor;
    public GameObject tileEncaixado;
    private Color defaultTileColor;
    public bool DevMode;

    void Start()
    {
	defaultTileColor = _rightColor;
	GetComponent<Renderer>().material.color = defaultTileColor;
    }

    void OnMouseEnter()
    {
	GetComponent<Renderer>().material.color = _wrongColor;

	if(DevMode == true)
	{
		Debug.Log("Mouse over: " + gameObject.name);
	}
    }

    void OnMouseExit()
    {
	GetComponent<Renderer>().material.color = defaultTileColor;
    }

    void OnMouseDown()
    {
	var raio = GameObject.Find("raioSolar");
	string TileName = gameObject.name;
	GameObject hangover = GameObject.Find("hangedObject");
	
	if(hangover != null && tileEncaixado == null && raio.GetComponent<movimento_do_raio>().direcaoLuz == Vector3.zero)
	{
	    hangover.GetComponent<Transform>().position = 
		gameObject.transform.position;

	    hangover.GetComponent<Renderer>().enabled = true;
	    hangover.name = $"objetoEncaixado";
	    tileEncaixado = hangover;
	}
    }
}
