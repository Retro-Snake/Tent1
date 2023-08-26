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

            // ���������� �������� ��� ������� ��� �������� �������� �������� �������
            PlanDvij(child, alpha);
        }
    }
       
 }

