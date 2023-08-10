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
        
        // ���������� ��� �������� �������
        foreach (Transform child in parent)
        {
            // �������� ��������� SpriteRenderer � ��������� �������
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

            // ���� ��������� SpriteRenderer ����, �������� �����-��������
            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color.a = alpha;
                spriteRenderer.color = color;
            }                      

            // ���������� �������� ��� ������� ��� �������� �������� �������� �������
            PlanDvij(child, alpha);
        }
    }
       
 }

