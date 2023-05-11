using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerUI : MonoBehaviour
{
    [SerializeField] private GameObject muteButton;
    [SerializeField] private GameObject unmuteButton;

    void Start()
    {
        if (AudioManager.instance.IsMuted())
        {
            muteButton.SetActive(false);
            unmuteButton.SetActive(true);
        }
        if (!AudioManager.instance.IsMuted())
        {
            unmuteButton.SetActive(false);
            muteButton.SetActive(true);
        }
    }

    public void OnMute()
    {
        unmuteButton.SetActive(true);
        AudioManager.instance.OnMute();
        muteButton.SetActive(false);
    }

    public void OnUnmute()
    {
        unmuteButton.SetActive(false);
        AudioManager.instance.OnUnmute();
        muteButton.SetActive(true);
    }
}