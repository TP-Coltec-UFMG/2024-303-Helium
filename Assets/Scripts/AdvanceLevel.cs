using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceLevel : MonoBehaviour
{
    void Start(){
        int level = PlayerPrefs.GetInt("Level", 1);

        if(level){
            PlayerPrefs.SetInt("Level", ++level);
        } else {
            PlayerPrefs.SetInt("Level", 1);
        }
    }
}
