using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLoadStart : MonoBehaviour
{
    public SaveManager progressManager;
    public float saveInterval = 10.0f; // Интервал сохранения в секундах

    private void Start()
    {
        progressManager = FindObjectOfType<SaveManager>();
       
        
        StartCoroutine(ExecuteAfterStart());
    }

    private IEnumerator ExecuteAfterStart()
    {
        yield return new WaitForEndOfFrame(); // Ожидаем до следующего кадра

        // Выполняем вашу функцию с отсрочкой
        StartAutoSave();
    }
    private void StartAutoSave()
    {
        progressManager.LoadGame();
        InvokeRepeating("AutoSave", saveInterval, saveInterval);
    }

    private void AutoSave()
    {
        
        progressManager.SaveGame(); // Вызываем метод сохранения из вашего SaveManager
        Debug.Log("Автоматическое сохранение выполнено.");
    }
}
