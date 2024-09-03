using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaioLuzToggle : MonoBehaviour
{
    public GameObject ObjetoFeixeDeLuz;
    public bool raioOnOff;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
    var Luz = ObjetoFeixeDeLuz.GetComponent<movimento_do_raio>();

	if(raioOnOff == true)
	{
	    raioOnOff = false;
	    Debug.Log(Luz);
	    Luz.direcaoLuz = Vector3.zero;
	    ObjetoFeixeDeLuz.transform.position = Luz.posInicial;

	    Luz.lineRenderer.positionCount = 2;

	    Vector3[] positions = {Luz.posInicial, Luz.posInicial};

	    Luz.lineRenderer.SetPositions(positions);
	}
	else
	{
	    raioOnOff = true;
	    Luz.direcaoLuz = Vector3.down;
	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
