using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPlatform : MonoBehaviour
{
    [SerializeField] private LayerMask road;
    [SerializeField] private GameObject roadline;

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
}
