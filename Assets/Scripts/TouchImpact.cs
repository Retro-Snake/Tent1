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


    void Start()    {
        rend = GetComponent<SpriteRenderer>();
        colliderToCompare = GetComponent<Collider2D>();
        progressManager = FindObjectOfType<SaveManager>();
        scoreUpdate = FindObjectOfType<UpdateScore>();
        StartColor = rend.color;
    }

    // Update is called once per frame
    void Update()
    {    
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                if (colliderToCompare.OverlapPoint(touchPosition) && (rend.color != newColor))
                {                   
                    UpdateColor(newColor);
                    // Точка касания находится внутри коллайдера объекта
                    Debug.Log("Цвет поменял у Объекта:" + gameObject.name);

                    scoreUpdate.UpdateNumberText(progressManager.progressFileName,1);// активируем изменение счёта
                    progressManager.SaveGame();
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
