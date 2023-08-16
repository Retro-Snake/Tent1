using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [Header ("—писок камер(Ќ”Ћ≈¬јя  јћ≈–ј ƒ≈‘‘ќЋ“Ќјя)")] 
    public List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();


    private void Start()
    {
        // ¬ключаем только первую камеру в начале
        if (cameras.Count > 0)
        {
            cameras[0].gameObject.SetActive(true);

            for (int i = 1; i < cameras.Count; i++)
            {
                cameras[i].gameObject.SetActive(false);
            }
        }
    }

    public void SwitchToCamera(int cameraIndex)
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].gameObject.SetActive(i == cameraIndex);
        }
    }
}
