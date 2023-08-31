using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlStart : MonoBehaviour
{
    public int lvlnum;
    public GameObject EscapeWarning;
    public float animSec = 1f;
    public Animator transition;
    public string animName;
    
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
        StartCoroutine(LoadAnim());

    }

    IEnumerator LoadAnim( )
    {
        if (transition != null && animName != (""))
        {
            transition.SetTrigger(animName);
        }
        else
        {
            animSec = 0;
        }
        
        yield return new WaitForSeconds(animSec);   
        SceneManager.LoadScene(lvlnum);
    }

}
