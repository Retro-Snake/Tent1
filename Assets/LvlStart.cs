using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlStart : MonoBehaviour
{
    public int lvlnum;

    public void PlayLvl()
    {
        SceneManager.LoadScene(lvlnum);
    }
}
