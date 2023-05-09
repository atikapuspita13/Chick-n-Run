using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton
    public static AudioManager instance { get; private set; }

    [SerializeField] private AudioClip drownSFX;
    [SerializeField] private AudioClip carCrashSFX;
    [SerializeField] private GameObject sfx;

    private AudioSource audioSource;
    private AudioSource audioSourceSFX;

    private PlayerLife player;

    private void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        audioSourceSFX = sfx.GetComponent<AudioSource>();
    }

    public void Play()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        audioSourceSFX.Stop();
    }

    public void OnMute()
    {
        audioSource.mute = true;
        audioSourceSFX.mute = true;
    }

    public void OnUnmute()
    {
        audioSource.mute = false;
        audioSourceSFX.mute = false;
    }

    public void OnDrown()
    {
        audioSource.Stop();
        audioSourceSFX.PlayOneShot(drownSFX, 0.3f);
    }

    public void OnCarCrash()
    {
        audioSource.Stop();
        audioSourceSFX.PlayOneShot(carCrashSFX);
    }
}
