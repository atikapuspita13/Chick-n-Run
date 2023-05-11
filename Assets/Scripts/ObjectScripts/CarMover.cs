using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    [SerializeField] private float logLifetime = 15f;
    [SerializeField] private AudioSource carVolume;

    private RoadPlatform roadPlatform;

    private void Start()
    {
        roadPlatform = this.GetComponentInParent<RoadPlatform>();
    }

    void Update()
    {
        carVolume.volume = AudioManager.instance.audioSourceSFX.volume * 0.75f;
        if (transform.position.x <= -35 || transform.position.x >= 35)
        {
            transform.Translate(0, 0, 30 * Time.deltaTime);
        }
        else
        {
            transform.Translate(0, 0, roadPlatform.GetCarSpeed() * Time.deltaTime);
            Destroy(gameObject, logLifetime);
        }
    }
}