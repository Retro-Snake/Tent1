using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Peremena : MonoBehaviour
{
    public GameObject FLpoint;
    private Vector3 myTransform;
    private float indexZTransform;
    private float indexYTransform ;
    private float indexY = 200f;
    [Header("�� ����� ���������� �� z ��������")]
    public float indexZ;
    //public float newAlpha = 0.5f;

    private void Start()
    {
        myTransform = transform.position;
        indexZTransform = myTransform.z; 
        indexYTransform = myTransform.y;
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
                    myTransform.z = indexZ;
                    myTransform.y = indexY;
                    transform.position = myTransform;
                }
                else
                {
                    myTransform.z = indexZTransform;
                    myTransform.y = indexYTransform;
                    transform.position = myTransform;
                }
            }                      

            // ���������� �������� ��� ������� ��� �������� �������� �������� �������
            PlanDvij(child, alpha);
        }
    }
       
 }

