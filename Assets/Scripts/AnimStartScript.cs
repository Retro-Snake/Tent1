using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimStartScript : MonoBehaviour
{
    public float animSec = 1f;
    public Animator transition;
    public string animName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAnim());
    }
      

    IEnumerator LoadAnim()
    {        
            transition.SetTrigger(animName);
            yield return new WaitForSeconds(animSec);
        
    }
}
