using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton
    public static AudioManager instance { get; private set; }

    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;

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
    }

    private void Update()
    {
        if(player == null)
        {
            player = FindObjectOfType<PlayerLife>();
        }
        else
        {
            if (player.isDead)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(audioClip);
            }
        }
    }

    public void Play()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void OnMute()
    {
        audioSource.mute = true;
    }

    public void OnUnmute()
    {
        audioSource.mute = false;
    }
}
