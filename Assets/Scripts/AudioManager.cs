using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup musicGroup;
    public AudioMixerGroup sfxGroup;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = musicGroup;
        audioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = sfxGroup;
        audioSource.Play();
    }
}
