using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] spawnObjects;

    private int spawnPointIndex;
    private int spawnObjectIndex;

    private float spawnTime;
    private float elapsedTime;
    private float logSpeed;

    private void Start()
    {
        spawnTime = Random.Range(1.5f, 2f);
        //spawnPointIndex = Random.Range(0, spawnPoints.Length);
        spawnObjectIndex = Random.Range(0, spawnObjects.Length);
        logSpeed = Random.Range(5f, 10f);
        elapsedTime = spawnTime;

        if (transform.position.z % 10 == 0)
        {
            spawnPointIndex = 0;
        }
        else
        {
            spawnPointIndex = 1;
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= spawnTime)
        {
            Instantiate(spawnObjects[spawnObjectIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].localRotation, spawnPoints[spawnPointIndex]);
            elapsedTime = 0;
        }
    }

    public float GetLogSpeed()
    {
        return logSpeed;
    }
}
