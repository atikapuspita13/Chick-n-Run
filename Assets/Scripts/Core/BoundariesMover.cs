using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesMover : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        //if (Vector3.Distance(new Vector3(0,0,transform.position.z), new Vector3(0, 0, player.position.z)) < 35)
        //{
        //}
        if(transform.position.z < player.position.z)
        {
            transform.position = player.position;
        }
    }
}
