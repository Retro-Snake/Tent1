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
        #region Зум/Zoom
        if (Input.touchCount == 2)
        {
            Touch touchFirst = Input.GetTouch(0);// Переменные под 1 и 2 прикосновение пальцев
            Touch touchSecond = Input.GetTouch(1);

            Vector2 touchFirstLastPos = touchFirst.position - touchFirst.deltaPosition;// понимание где мы на экране коснулись первым пальцем
            Vector2 touchSecondLastPos = touchSecond.position - touchSecond.deltaPosition;// понимание где мы на экране коснулись вторым пальцем

            float distTouch = (touchFirstLastPos - touchSecondLastPos).magnitude;// расстояние между нашими пальцами 
            float currentDistTouch = (touchFirst.position - touchSecond.position).magnitude;

            float difference = currentDistTouch - distTouch;//разница между новым положение пальцев и изначальным 

            float zoomDelta = -difference * zoomSpeed;

            //float zoomDelta = -Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            currentZoom += zoomDelta;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            // Применяем изменение масштаба камеры
            virtualCamera.m_Lens.OrthographicSize = currentZoom;

            UpdateColliderSize();
        }
        #endregion
    }
    // часть кода для коллайдера необходима -  ДЛЯ ПРИРАВНИВАНИЯ ХИТ БОКСА ОБЪЕКТА ПЕРЕМЕШЕНИЯ(FollowPoint) К РАЗМЕРАМ ВИДИМОЙ КАМЕРЫ. НУЖНО ЧТО БЫ КАМЕРА В БОКАХ НЕ ТУПИЛА
    #region РазмерКоллайдера/ CollaiderSizeUpdate
    private BoxCollider2D boxCollider; // берём переменную для коллайдера
    void UpdateColliderSize()
    {
        virtualCamera = FindAnyObjectByType<CinemachineVirtualCamera>();// присваиваем переменной активную камеру
        boxCollider = GetComponent<BoxCollider2D>(); //присваеваем переменной наш бокс коллайдер
        if (virtualCamera != null && boxCollider != null) // Проверяем пустые ли значения 
        {
            float cameraHeight = virtualCamera.m_Lens.OrthographicSize * 2f;// Переменная для понимания высоты. Берём из виртуальной камеры ортографическое значение высоты(что является половиной реальной высоты) и умножаем на 2
            float cameraWidth = cameraHeight * virtualCamera.m_Lens.Aspect;// Переменная для ширины. Берём нашу высоту и умножаем на число - соотношения сторон(Aspect) 

            boxCollider.size = new Vector2(cameraWidth, cameraHeight);// присвоение уже реальному коллайдеру наши полученные значения
        }
    }
    #endregion
}
