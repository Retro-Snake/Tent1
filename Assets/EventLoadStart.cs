using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        InvokeRepeating("AutoSave", saveInterval, saveInterval);
    }

    private void AutoSave()
    {
        
        progressManager.SaveGame(); // �������� ����� ���������� �� ������ SaveManager
        Debug.Log("�������������� ���������� ���������.");
    }
}
