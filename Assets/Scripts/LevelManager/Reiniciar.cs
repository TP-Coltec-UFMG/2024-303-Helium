using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Reiniciar : MonoBehaviour
{
    public GameObject sol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
	sol.GetComponent<RaioLuzToggle>().reiniciarLuz();	
	var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "refletor");
	foreach (var obj in objects)
	{
	    Destroy(obj);
	}
    }
}
