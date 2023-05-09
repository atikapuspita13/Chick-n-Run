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

    private void Update()
    {
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
