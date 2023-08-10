using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Peremena : MonoBehaviour
{
    public GameObject FLpoint;
    private Transform myTransform;
    //public float newAlpha = 0.5f;

    private void Start()
    {
        
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
            }                      

            // Рекурсивно вызываем эту функцию для дочерних объектов текущего объекта
            PlanDvij(child, alpha);
        }
    }
       
 }

