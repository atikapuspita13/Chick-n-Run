using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMover : MonoBehaviour
{
    [SerializeField] private float logLifetime = 15f;
    private WaterPlatform waterPlatform;

    private void Start()
    {
        waterPlatform = this.GetComponentInParent<WaterPlatform>();
    }

    void Update()
    {
        if (transform.position.x <= -35 || transform.position.x >= 35)
        {
            transform.Translate(0, 0, 30 * Time.deltaTime);
        }
        else
        {
            transform.Translate(0, 0, waterPlatform.GetLogSpeed() * Time.deltaTime);
            Destroy(gameObject, logLifetime);
        }
    }
}
