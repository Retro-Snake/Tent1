using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [Header("�������� ��������� ����")]
    public GameObject Main;

    private void Start()
    {
        Application.targetFrameRate = 90;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Main.activeSelf)// �������� ������� ������ �����. ���� ������� ���� ������� ������� �� ����, ����� ��������� ��� ������� ���� � ��������-���������� � ������� ����.
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
