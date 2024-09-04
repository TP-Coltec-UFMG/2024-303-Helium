using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorblindFilters : MonoBehaviour{
    public Toggle toggleNone;
    public Toggle toggleProtanopia;
    public Toggle toggleDeuteranopia;
    public Toggle toggleTritanopia;
    public Toggle toggleAchromatopsia;

    public CameraController cam;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
        // Read values
        toggleNone.isOn = (PlayerPrefs.GetInt("ToggleBool") == 1);
        toggleProtanopia.isOn = (PlayerPrefs.GetInt("ToggleBool1") == 1);
        toggleDeuteranopia.isOn = (PlayerPrefs.GetInt("ToggleBool2") == 1);
        toggleTritanopia.isOn = (PlayerPrefs.GetInt("ToggleBool3") == 1);
        toggleAchromatopsia.isOn = (PlayerPrefs.GetInt("ToggleBool4") == 1);

        // Debug.Log("Loaded" + toggleNone.isOn + toggleProtanopia.isOn + toggleDeuteranopia.isOn + toggleTritanopia.isOn + toggleAchromatopsia.isOn);
    }

    void Update()
    {
        // Write values
        if(toggleNone.isOn){
            PlayerPrefs.SetInt("ToggleBool", 1);
            cam.filter.mode = ColorBlindMode.Normal;
        } else PlayerPrefs.SetInt("ToggleBool", 0);
        if(toggleProtanopia.isOn){
            PlayerPrefs.SetInt("ToggleBool1", 1);
            cam.filter.mode = ColorBlindMode.Protanopia;
        } else PlayerPrefs.SetInt("ToggleBool1", 0);
        if(toggleDeuteranopia.isOn){
            PlayerPrefs.SetInt("ToggleBool2", 1);
            cam.filter.mode = ColorBlindMode.Deuteranopia;
        } else PlayerPrefs.SetInt("ToggleBool2", 0);
        if(toggleTritanopia.isOn){
            PlayerPrefs.SetInt("ToggleBool3", 1);
            cam.filter.mode = ColorBlindMode.Tritanopia;
        } else PlayerPrefs.SetInt("ToggleBool3", 0);
        if(toggleAchromatopsia.isOn){
            PlayerPrefs.SetInt("ToggleBool4", 1);
            cam.filter.mode = ColorBlindMode.Achromatopsia;
        } else PlayerPrefs.SetInt("ToggleBool4", 0);
    }
}