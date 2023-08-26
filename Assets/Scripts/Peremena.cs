using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Peremena : MonoBehaviour
{
    public GameObject FLpoint;
    private Vector3 myTransform;
    private float indexZTransform;
    //public float newAlpha = 0.5f;

    private void Start()
    {
        myTransform = transform.position;
        indexZTransform = myTransform.z;        
    }
    public void PlanDvij(Transform parent, float alpha)
    {
        
        // Перебираем все дочерние объекты
        foreach (Transform child in parent)
        {
            // Получаем компонент SpriteRenderer у дочернего объекта
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

            // Если компонент SpriteRenderer есть, изменяем альфа-значение
            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color.a = alpha;
                spriteRenderer.color = color;
                if(alpha == 0)
                {
                    myTransform.z = 5;
                    transform.position = myTransform;
                }
                else
                {
                    myTransform.z = indexZTransform;
                    transform.position = myTransform;
                }
            }                      

            // Рекурсивно вызываем эту функцию для дочерних объектов текущего объекта
            PlanDvij(child, alpha);
        }
    }
       
 }

