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

    public AudioSource audioSource { get; private set; }
    public AudioSource audioSourceSFX { get; private set; }
    private AudioListener audioListener;

    private PlayerLife player;

    private bool isMuted;

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
        audioListener = GetComponent<AudioListener>();
    }

    public void OnPlay()
    {
        if (!instance.audioSource.isPlaying)
        {
            instance.audioSource.Play();
        }
    }

    public void OnMute()
    {
        isMuted = true;

        instance.audioSource.mute = true;
        instance.audioSourceSFX.mute = true;
        instance.audioListener.enabled = false;
    }

    public void OnUnmute()
    {
        isMuted = false;

        instance.audioSource.mute = false;
        instance.audioSourceSFX.mute = false;
        instance.audioListener.enabled = true;
    }

    public void OnDrown()
    {
        instance.audioSource.Stop();
        instance.audioSourceSFX.PlayOneShot(drownSFX, 0.4f * instance.audioSourceSFX.volume);
    }

    public void OnCarCrash()
    {
        instance.audioSource.Stop();
        instance.audioSourceSFX.PlayOneShot(carCrashSFX, 1.35f * instance.audioSourceSFX.volume);
    }

    public bool IsMuted()
    {
        return isMuted;
    }
}
