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

    void Start()
    {
        // Read values
        toggleNone.isOn = (PlayerPrefs.GetInt("ToggleBool") == 1);
        toggleProtanopia.isOn = (PlayerPrefs.GetInt("ToggleBool1") == 1);
        toggleDeuteranopia.isOn = (PlayerPrefs.GetInt("ToggleBool2") == 1);
        toggleTritanopia.isOn = (PlayerPrefs.GetInt("ToggleBool3") == 1);
        toggleAchromatopsia.isOn = (PlayerPrefs.GetInt("ToggleBool4") == 1);
    }

    void Update()
    {
        // Write values
        PlayerPrefs.SetInt("ToggleBool", (toggleNone.isOn == true ? 1 : 0));
        PlayerPrefs.SetInt("ToggleBool1", (toggleProtanopia.isOn == true ? 1 : 0));
        PlayerPrefs.SetInt("ToggleBool2", (toggleDeuteranopia.isOn == true ? 1 : 0));
        PlayerPrefs.SetInt("ToggleBool3", (toggleTritanopia.isOn == true ? 1 : 0));
        PlayerPrefs.SetInt("ToggleBool4", (toggleAchromatopsia.isOn == true ? 1 : 0));
    }
}