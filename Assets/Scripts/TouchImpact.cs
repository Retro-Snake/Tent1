using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TouchImpact : MonoBehaviour
{
    private SpriteRenderer rend ;
    public Color newColor;

    private Collider2D colliderToCompare;


    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
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

                if (colliderToCompare.OverlapPoint(touchPosition) && (rend.color != newColor))
                {
                    UpdateColor(newColor);
                    // Точка касания находится внутри коллайдера объекта
                    Debug.Log("Цвет поменял у Объекта:" + gameObject.name);
                }                
            }
        }
    }
    
    private void UpdateColor(Color color)
    {
        rend.color = color;        
    }

}
