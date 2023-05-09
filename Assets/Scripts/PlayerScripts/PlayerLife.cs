using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;

    private PlayerController playerController;

    public bool isDead { get; private set; } = false;
    public bool deathByDriftAway { get; private set; } = false;
    public bool deathByCar { get; private set; } = false;
    public bool deathByDrown { get; set; } = false;

    private void Awake()
    {
        instance = this;
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Killer_DriftAway")
        {
            Die();
        }
        else if (other.gameObject.tag == "Killer_Car")
        {
            Die();
            transform.position = other.transform.position;
            deathByCar = true;
        }
    }

    public void Die()
    {
        FindObjectOfType<CinemachineVirtualCamera>().Follow = null;
        playerController.enabled = false;
        GameManager.instance.GameOver();
        isDead = true;
    }
}
