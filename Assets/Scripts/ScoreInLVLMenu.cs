using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreInLVLMenu : MonoBehaviour
{
    public TextMeshProUGUI TextScore;
    public string LvlScore;
    public int actualScore;

    void Awake()
    {        
        CheckScore();
    }

    public void CheckScore()
    {
        
        actualScore = PlayerPrefs.HasKey(LvlScore) ? PlayerPrefs.GetInt(LvlScore): 0;
        ScoreUpdateText(actualScore);

    }


    public void ScoreUpdateText(int ScoreUpdate)
    {
                
        if (TextScore != null)
        {
            TextScore.text = ScoreUpdate.ToString("000");
        }                
    }
    
}
