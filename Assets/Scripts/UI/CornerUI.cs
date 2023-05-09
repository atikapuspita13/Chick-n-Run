using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerUI : MonoBehaviour
{
    [SerializeField] private GameObject muteButton;
    [SerializeField] private GameObject unmuteButton;

    private bool mute;
    // Start is called before the first frame update
    void Start()
    {
        mute = false;
        muteButton.SetActive(true);
        unmuteButton.SetActive(false);
    }

    public void OnMute()
    {
        mute = true;
    }

    public void OnUnmute()
    {
        mute = false;
    }

    private void Update()
    {
        if (mute)
        {
            unmuteButton.SetActive(true);
            AudioManager.instance.OnMute();
            muteButton.SetActive(false);
        }
        else
        {
            unmuteButton.SetActive(false);
            AudioManager.instance.OnUnmute();
            muteButton.SetActive(true);
        }
    }
}
