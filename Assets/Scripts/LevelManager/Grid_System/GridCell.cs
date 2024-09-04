using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] private Color _rightColor, _wrongColor;
    private Color defaultTileColor;
    public bool DevMode;
    public string tag = "gridTile";

    void Start()
    {
	defaultTileColor = _rightColor;
	GetComponent<Renderer>().material.color = defaultTileColor;
	gameObject.tag = tag;
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
	string TileName = gameObject.name;
	GameObject hangover = GameObject.Find("hangedRefletor");
	
	if(hangover != null && GameObject.Find($"{gameObject.name}.refletor") == null)
	{
	    hangover.GetComponent<Transform>().position = 
		gameObject.transform.position + new Vector3(0,0,-1);

	    hangover.GetComponent<Renderer>().enabled = true;
	    hangover.name = $"{gameObject.name}.refletor";
	}
    }
}
