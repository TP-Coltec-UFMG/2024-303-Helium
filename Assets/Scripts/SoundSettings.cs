using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    // The range of the volume slider on a mixer group
    const float minVolume = -80f;
    const float maxVolume = 20f;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] AudioMixer mixer;
    private void Start()
    {
        if(PlayerPrefs.HasKey("savedMusicVolume") || PlayerPrefs.HasKey("savedSFXVolume"))
        {
            LoadVolume();
            Debug.Log("Carregado: Music = " + PlayerPrefs.GetFloat("savedMusicVolume") + "; SFX = " + PlayerPrefs.GetFloat("savedSFXVolume") + ';');
        } else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float newVolume = musicSlider.value;

        musicSlider.value = newVolume;
        PlayerPrefs.SetFloat("savedMusicVolume", newVolume);
        mixer.SetFloat("MusicVolume", Mathf.Log10(newVolume / 100) * 20f); // minVolume(Log10(10^-4)*20)dB a maxVolume (Log10(10)*20)dB
    }
    public void SetSFXVolume()
    {
        float newVolume = SFXSlider.value;

        SFXSlider.value = newVolume;
        PlayerPrefs.SetFloat("savedSFXVolume", newVolume);
        mixer.SetFloat("SFXVolume", Mathf.Log10(newVolume / 100) * 20f);

    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("savedMusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("savedSFXVolume");

        SetMusicVolume();
        SetSFXVolume();
    }
}
