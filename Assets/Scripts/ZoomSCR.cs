using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomSCR : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float zoomSpeed = 0.1f;
    public float minZoom = 2f;
    public float maxZoom = 10f;
    public float currentZoom = 5f;

    

    private void Start()
    {
        UpdateColliderSize();
    }

    private void Update()
    {
        #region ���/Zoom
        if (Input.touchCount == 2)
        {
            Touch touchFirst = Input.GetTouch(0);// ���������� ��� 1 � 2 ������������� �������
            Touch touchSecond = Input.GetTouch(1);

            Vector2 touchFirstLastPos = touchFirst.position - touchFirst.deltaPosition;// ��������� ��� �� �� ������ ��������� ������ �������
            Vector2 touchSecondLastPos = touchSecond.position - touchSecond.deltaPosition;// ��������� ��� �� �� ������ ��������� ������ �������

            float distTouch = (touchFirstLastPos - touchSecondLastPos).magnitude;// ���������� ����� ������ �������� 
            float currentDistTouch = (touchFirst.position - touchSecond.position).magnitude;

            float difference = currentDistTouch - distTouch;//������� ����� ����� ��������� ������� � ����������� 

            float zoomDelta = -difference * zoomSpeed;

            //float zoomDelta = -Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            currentZoom += zoomDelta;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            // ��������� ��������� �������� ������
            virtualCamera.m_Lens.OrthographicSize = currentZoom;

            UpdateColliderSize();
        }
        #endregion
    }
    // ����� ���� ��� ���������� ���������� -  ��� ������������� ��� ����� ������� �����������(FollowPoint) � �������� ������� ������. ����� ��� �� ������ � ����� �� ������
    #region ����������������/ CollaiderSizeUpdate
    private BoxCollider2D boxCollider; // ���� ���������� ��� ����������
    void UpdateColliderSize()
    {
        virtualCamera = FindAnyObjectByType<CinemachineVirtualCamera>();// ����������� ���������� �������� ������
        boxCollider = GetComponent<BoxCollider2D>(); //����������� ���������� ��� ���� ���������
        if (virtualCamera != null && boxCollider != null) // ��������� ������ �� �������� 
        {
            float cameraHeight = virtualCamera.m_Lens.OrthographicSize * 2f;// ���������� ��� ��������� ������. ���� �� ����������� ������ ��������������� �������� ������(��� �������� ��������� �������� ������) � �������� �� 2
            float cameraWidth = cameraHeight * virtualCamera.m_Lens.Aspect;// ���������� ��� ������. ���� ���� ������ � �������� �� ����� - ����������� ������(Aspect) 

            boxCollider.size = new Vector2(cameraWidth, cameraHeight);// ���������� ��� ��������� ���������� ���� ���������� ��������
        }
    }
    #endregion
}
