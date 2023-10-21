using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UpdateScore : MonoBehaviour
{
    public TextMeshProUGUI TextScore;    
    public int currentScore = 0;
        
    public void UpdateNumberText(string lvlName,int scorReset)
    {
        currentScore++; 
        currentScore = scorReset * currentScore; 
        TextScore.text = currentScore.ToString("000");
        PlayerPrefs.SetInt(lvlName, currentScore);
        PlayerPrefs.Save();
    }
    public void LoadScore(string lvlName)
    {
        int actualScore = PlayerPrefs.GetInt(lvlName); 
        currentScore = actualScore;
        TextScore.text = actualScore.ToString("000"); 
    }
}
