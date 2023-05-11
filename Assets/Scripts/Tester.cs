using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    AudioListener[] boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = FindObjectsOfType<AudioListener>();
        print(boxCollider.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
