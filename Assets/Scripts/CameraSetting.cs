using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSetting : MonoBehaviour
{
    
    public Slider slider;
    void Start()
    {
       float speed = PlayerPrefs.GetFloat("CameraSpeed", 0.2f);
       slider.value = speed;
    }

    public void SetCameraSpeed(float CameraSpeadVal)
    {
        PlayerPrefs.SetFloat("CameraSpeed",CameraSpeadVal);
    }
}
