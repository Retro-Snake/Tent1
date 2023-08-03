using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
   public int LvlNumber; // Переменная открытого типа для того что бы в инспекторе можно было вбить значения,А не увеличивать сложность кода

    public void PlayGame()
    {
        SceneManager.LoadScene(LvlNumber); // Запуск сцены с индексом из переменной 
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
