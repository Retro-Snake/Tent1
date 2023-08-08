using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{
    private Touch touch;    
    public float speedCam = 0.5f;
    public GameObject Plan;
    void Update()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {                
                transform.Translate(new Vector2(touch.deltaPosition.x,touch.deltaPosition.y)*speedCam*Time.deltaTime*-1, Space.World);

                #region ����������� ��������� �����
                // ��� ����������� ����� ������ ������� folloPoin � ��������� ������ ������� ��������� �����
                if (Plan != null) // ��������� ���� �� ������ ��������� ����� 
                {
                    //Plan.GetComponent<Peremena>().PlanDvij(Plan.transform,0);
                }
                #endregion
            }


        }


    }
}
