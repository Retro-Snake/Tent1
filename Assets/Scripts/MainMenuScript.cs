using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject Main;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Main.activeSelf)// проверка нажати€ кнопки назад. ≈сли главное меню активно выходит из игры, иначе выключает все аспекты меню и включает-возвращает в главное меню.
        {            
            QuitGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            Main.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Debug.Log("Quit!" );
        Application.Quit();
    }
}
