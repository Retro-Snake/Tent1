using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlStart : MonoBehaviour
{
    public int lvlnum;
    public GameObject EscapeWarning;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (EscapeWarning.activeSelf) 
            { 
             EscapeWarning.SetActive(false);
                return;
            }
            
            EscapeWarning.SetActive(true);
        }
    }
    public void PlayLvl()
    {
        SceneManager.LoadScene(lvlnum);
    }
}
