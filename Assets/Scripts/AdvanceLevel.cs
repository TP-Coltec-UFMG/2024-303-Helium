using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceLevel : MonoBehaviour
{
    void Start(){
        int level = getLevel();

        advanceLevel(level);
    }
    int getLevel(){
        return PlayerPrefs.GetInt("Level", 1);
    }

    void advanceLevel(int level){
        if(level > 1){
            PlayerPrefs.SetInt("Level", ++level);
        } else {
            PlayerPrefs.SetInt("Level", 1);
        }
    }
}
