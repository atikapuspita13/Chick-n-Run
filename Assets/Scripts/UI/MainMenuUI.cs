using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject[] mainScreen;
    [SerializeField] private GameObject[] optionsScreen;

    [SerializeField] private Slider volumeBGM;
    [SerializeField] private Slider volumeSFX;

    void Start()
    {
        foreach (GameObject gameObject in mainScreen)
        {
            gameObject.SetActive(true);
        }

        foreach (GameObject gameObject in optionsScreen)
        {
            gameObject.SetActive(false);
        }

        volumeBGM.value = AudioManager.instance.audioSource.volume;
        volumeSFX.value = AudioManager.instance.audioSourceSFX.volume;
    }

    private void Update()
    {
        AudioManager.instance.audioSource.volume = volumeBGM.value;
        AudioManager.instance.audioSourceSFX.volume = volumeSFX.value;
    }

    public void OptionsMenu()
    {
        foreach (GameObject gameObject in mainScreen)
        {
            gameObject.SetActive(false);
        }

        foreach (GameObject gameObject in optionsScreen)
        {
            gameObject.SetActive(true);
        }
    }

    public void MainMenu()
    {
        foreach (GameObject gameObject in mainScreen)
        {
            gameObject.SetActive(true);
        }

        foreach (GameObject gameObject in optionsScreen)
        {
            gameObject.SetActive(false);
        }
    }
}
