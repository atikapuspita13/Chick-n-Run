using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPlatform : MonoBehaviour
{
    [SerializeField] private LayerMask road;
    [SerializeField] private GameObject roadline;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] spawnObjects;

    private int spawnPointIndex;
    private int spawnObjectIndex;

    private float spawnTime;
    private float elapsedTime;

    private float carSpeed;

    private bool isActive;

    private void Start()
    {
        spawnTime = Random.Range(3f, 5f);
        //spawnPointIndex = Random.Range(0, spawnPoints.Length);
        spawnObjectIndex = Random.Range(0, spawnObjects.Length);
        carSpeed = Random.Range(10f, 20f);
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

        roadline.SetActive(isActive);
        if (isActive) return;
        if (Physics.Raycast(transform.position, Vector3.forward, 3, road))
        {
            isActive = true;
        }
    }

    public float GetCarSpeed()
    {
        return carSpeed;
    }
}
