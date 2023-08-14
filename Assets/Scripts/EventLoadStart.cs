using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//���������� ������ ��������� ��� �������� ���������� ��� ������� �����
public class EventLoadStart : MonoBehaviour
{
    public SaveManager progressManager;
    public float saveInterval = 10.0f; // �������� ���������� � ��������

    private void Start()
    {
        progressManager = FindObjectOfType<SaveManager>();
               
        StartCoroutine(ExecuteAfterStart());
    }

    private IEnumerator ExecuteAfterStart()
    {
        yield return new WaitForEndOfFrame(); // ������� �� ���������� �����

        // ��������� ���� ������� � ���������
        StartAutoSave();
    }
    private void StartAutoSave()
    {        
            progressManager.LoadGame();        
    }
    
}
