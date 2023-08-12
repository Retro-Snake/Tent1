using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public TextMeshProUGUI TextScore;
    public int currentScore = 0;
    
    public void UpdateNumberText()
    {
        currentScore++;
        TextScore.text = currentScore.ToString("000");
    }
}
