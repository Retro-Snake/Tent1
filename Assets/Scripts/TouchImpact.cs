using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SaveManager;
using static UnityEngine.GraphicsBuffer;
using System.IO;


public class TouchImpact : MonoBehaviour
{
    public SpriteRenderer rend ;
    public Color newColor;
    private Color StartColor;
    public UpdateScore scoreUpdate;
    private Collider2D colliderToCompare;
    private SaveManager progressManager;
    private Vector3 previousPosition;
    private Camera CameraTran;
    private Vector3 cameraPreviousPosition; // Предыдущая позиция камеры

    void Start()    
    {
        rend = GetComponent<SpriteRenderer>();
        colliderToCompare = GetComponent<Collider2D>();
        progressManager = FindObjectOfType<SaveManager>();
        scoreUpdate = FindObjectOfType<UpdateScore>();
        StartColor = rend.color;
        CameraTran = FindAnyObjectByType<Camera>();
        cameraPreviousPosition = CameraTran.transform.position;// Инициализируем начальную позицию камеры
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = CameraTran.transform.position;// Текущая позиция камеры
        float distance = Vector3.Distance(currentPosition, cameraPreviousPosition); // Расстояние между текущей и предыдущей позициями
        
        cameraPreviousPosition = currentPosition; // Обновляем предыдущую позицию для следующего кадра  
        if (distance < 0.1)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended)
                {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                    RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);                    
                    if ((rend.color != newColor) && (hit.collider != null) && (hit.collider.gameObject == gameObject))
                    {
                        UpdateColor(newColor);
                        // Точка касания находится внутри коллайдера объекта
                        Debug.Log("Цвет поменял у Объекта:" + gameObject.name);

                        scoreUpdate.UpdateNumberText(progressManager.progressFileName, 1);// активируем изменение счёта
                        progressManager.SaveGame();
                    }
                }
            }
        }
    }   

    private void UpdateColor(Color color)
    {        
        rend.color = color;
        
    }

    public void ResetToDefault()
    {
        // Восстанавливаем исходный цвет
        UpdateColor(StartColor);
        scoreUpdate.UpdateNumberText(progressManager.progressFileName,0);

    }

    public void LoadData(Save.TentSaveData save)
    {
        rend.color = new Color (save.TentColor.r, save.TentColor.g,save.TentColor.b,save.TentColor.a);
        scoreUpdate.LoadScore(progressManager.progressFileName);
    }


}
