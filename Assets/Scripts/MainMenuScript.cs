using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
   public int LvlNumber; // ���������� ��������� ���� ��� ���� ��� �� � ���������� ����� ���� ����� ��������,� �� ����������� ��������� ����

    public void PlayGame()
    {
        SceneManager.LoadScene(LvlNumber); // ������ ����� � �������� �� ���������� 
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
