using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI yourScoreDisplay;
    [SerializeField] private TextMeshProUGUI bestScoreDisplay;


    void Update()
    {
        yourScoreDisplay.text = ScoreKeeper.instance.GetCurrentScore().ToString("000000");
        if(bestScoreDisplay != null)
        {
            bestScoreDisplay.text = ScoreKeeper.instance.GetHighScore().ToString("000000");
        }
    }
}
