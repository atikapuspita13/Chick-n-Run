using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;



    private PlayerController playerController;

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
        //if (other.gameObject.tag == "Killer_DriftAway")
        //{
        //    Die();
        //    FindObjectOfType<CinemachineVirtualCamera>().Follow = null;
        //}
        //else if (other.gameObject.tag == "Killer_Car")
        //{
        //    Die();
        //    deathByCar = true;
        //}
    }

    public void Die()
    {
        FindObjectOfType<CinemachineVirtualCamera>().Follow = null;
        playerController.enabled = false;
        GameManager.instance.GameOver();
    }
}
