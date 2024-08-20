using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [SerializeField] private Color _rightColor, _wrongColor;
    private Color myColor;

    public void Init(bool isRightColor)
    {
	myColor = isRightColor ? _rightColor : _wrongColor;
	GetComponent<Renderer>().material.color = myColor;
    }

    void OnMouseOver()
    {
	GetComponent<Renderer>().material.color = Color.red;
	Debug.Log(gameObject.name + " diz : Ai, isso doi");
    }

    void OnMouseExit()
    {
	GetComponent<Renderer>().material.color = myColor;
    }

}
