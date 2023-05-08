using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    // Singleton
    public static ScoreKeeper instance { get; private set; }

    private PlayerController player;
    private int highestScore;
    private int currentScore;

    private void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }
        else
        {
            currentScore = player.GetScore();
            if (highestScore < player.GetScore())
            {
                highestScore = player.GetScore();
            }
        }
    }

    public int GetHighScore()
    {
        return highestScore;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
