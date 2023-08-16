using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLocation : MonoBehaviour
{
    private Collider2D colliderToCompare;

    public SwitchCamera cameraSwitcher;
    public int cameraIndexToSwitch; //Номер камеры на которую переключаемся
    void Start()
    {       
        colliderToCompare = GetComponent<Collider2D>();
        cameraSwitcher = FindObjectOfType<SwitchCamera>();
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

                    
                    cameraSwitcher.SwitchToCamera(cameraIndexToSwitch);


                    //gameObject.SetActive(true);

                    //CurrentLocation.SetActive(false);
                    //NextLocation.SetActive(true);
                    ////Выключаем не сцену , а игровой объект с его дочерними. В данном случаи необходимо для сохранения очков и удобства
                    //Debug.Log("Выключилась локация - " + CurrentLocation + "Переключились на локацию" + NextLocation);
                }
            }
        }
    }
}
