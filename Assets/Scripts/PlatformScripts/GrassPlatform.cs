using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] grass;
    [SerializeField] private GameObject[] tree;
    [SerializeField] private bool isStartPlatform;
    [SerializeField] private bool shouldSpawnFull;
    [SerializeField] private bool shouldNotSpawnRandom;
    [SerializeField, Range(1, 10)] private int randomizeDenominatorMin = 5;
    [SerializeField, Range(1, 10)] private int randomDenominatorMax = 5;

    private PlayerController player;

    private void Awake()
    {
        if (isStartPlatform) player = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        if (transform.position.z % 10 == 0)
        {
            grass[0].SetActive(true);
            grass[1].SetActive(false);
        }
        else
        {
            grass[0].SetActive(false);
            grass[1].SetActive(true);
        }

        if (isStartPlatform && shouldSpawnFull)
        {
            for (int spawnPos = 60; spawnPos >= -60; spawnPos -= 5)
            {
                Vector3 position = new Vector3(spawnPos, transform.position.y, transform.position.z);
                if (Vector3.Distance(position, player.transform.position) < 3) continue;

                int index = Random.Range(0, tree.Length);
                Instantiate(tree[index], position, Quaternion.identity, this.transform);
            }
        }
        else
        {
            for (int spawnPos = 35; spawnPos <= 60; spawnPos += 5)
            {
                int index = Random.Range(0, tree.Length);
                Instantiate(tree[index], new Vector3(spawnPos, transform.position.y, transform.position.z), Quaternion.identity, this.transform);
            }

            for (int spawnPos = -35; spawnPos >= -60; spawnPos -= 5)
            {
                int index = Random.Range(0, tree.Length);
                Instantiate(tree[index], new Vector3(spawnPos, transform.position.y, transform.position.z), Quaternion.identity, this.transform);
            }

            if (shouldNotSpawnRandom) return;
            for (float spawnPosRandom = -30f; spawnPosRandom <= 30f; spawnPosRandom += 5f)
            {
                int randomizeDenominator = Random.Range(randomizeDenominatorMin, Mathf.Clamp(randomDenominatorMax, randomizeDenominatorMin, randomDenominatorMax));
                int randomize = Random.Range(0, randomizeDenominator);
                if (randomize == 0)
                {
                    Vector3 position = new Vector3(spawnPosRandom, transform.position.y, transform.position.z);
                    if (isStartPlatform && Vector3.Distance(position, player.transform.position) < 3) continue;

                    int index = Random.Range(0, tree.Length);
                    Instantiate(tree[index], position, Quaternion.identity, this.transform);
                }
            }
        }
    }
}
