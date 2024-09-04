using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
	    reiniciarLuz();
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

    public void reiniciarLuz()
    {
	var Luz = ObjetoFeixeDeLuz.GetComponent<movimento_do_raio>();

	var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "raioSolarClone");
	foreach (var obj in objects)
	{
	    Destroy(obj);
	}

	Luz.direcaoLuz = Vector3.zero;
	Luz.contador.GetComponent<Contador>().zerar();
	ObjetoFeixeDeLuz.transform.position = Luz.posInicial;

	Luz.lineRenderer.positionCount = 2;

	Vector3[] positions = {Luz.posInicial, Luz.posInicial};

	Luz.lineRenderer.SetPositions(positions);
    }
}
