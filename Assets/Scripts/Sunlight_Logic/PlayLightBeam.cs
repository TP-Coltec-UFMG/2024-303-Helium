using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLightBeam : MonoBehaviour
{
    public GameObject objeto;
    private LightBeamController lbc;
    public GameObject obv1;
    public GameObject obv2;
    public GameObject obv3;

    // Start is called before the first frame update
    void Start()
    {
        lbc = objeto.GetComponent<LightBeamController>();
    }

    void OnMouseDown (){
        if (lbc.movimento == true){
            lbc.movimento = false;
            LineRenderer feixe = objeto.GetComponent<LineRenderer>();
            feixe.positionCount = 2;

            feixe.SetPosition(0, lbc.posInicial.position); 
            feixe.SetPosition(1, lbc.posInicial.position);

            lbc.transform.position = lbc.posInicial.position;

	    lbc.direcao_move_x = 0;
	    lbc.direcao_move_y = -1;

            obv1.SetActive(true);
            obv2.SetActive(true);
            obv3.SetActive(true);
        }else{
            lbc.movimento = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
