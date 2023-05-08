using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformSpawner;
    [SerializeField] GameObject[] platform;
    [SerializeField] private int maxChild = 20;

    private float platformPos = 0;
    private float nextPlatformPos = 0;


    private void Update()
    {
        for (platformPos = nextPlatformPos; platformSpawner.transform.childCount < maxChild; platformPos += 5f)
        {
            GameObject newPlatform = Instantiate(platform[Random.Range(0, platform.Length)], new Vector3(0, -0.5f, platformPos), Quaternion.identity, platformSpawner.transform);
            nextPlatformPos = newPlatform.transform.position.z + 5;
        }
    }
}
