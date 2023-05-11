using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMover : MonoBehaviour
{
    private PlayerController player;

    void Update()
    {
        if(player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }
        transform.position = player.transform.position;
    }
}
