using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLocation : MonoBehaviour
{
    public GameObject CurrentLocation;
    public GameObject NextLocation;
    private Collider2D colliderToCompare;
    void Start()
    {       
        colliderToCompare = GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                if (colliderToCompare.OverlapPoint(touchPosition))  // Точка касания находится внутри коллайдера объекта
                {

                    //gameObject.SetActive(true);

                    CurrentLocation.SetActive(false);
                    NextLocation.SetActive(true);
                    //Выключаем не сцену , а игровой объект с его дочерними. В данном случаи необходимо для сохранения очков и удобства
                    Debug.Log("Выключилась локация - " + CurrentLocation + "Переключились на локацию" + NextLocation);
                }
            }
        }
    }
}
