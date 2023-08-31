using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public float updateInterval = 0.5f; // �������� ���������� FPS (� ��������)
    public TextMeshProUGUI textMesh; // ������ �� ��������� TextMeshPro

    private float accum = 0.0f; // ����� ������� ��� ���������� FPS
    private int frames = 0; // ���������� ������ � ������� ���������� ����������
    private float timeLeft; // ����� �� ���������� ����������

    private void Start()
    {
        timeLeft = updateInterval;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        frames++;

        if (timeLeft <= 0.0f)
        {
            float fps = accum / frames;
            string text = string.Format("{0:F2} FPS", fps);
            textMesh.text = text;

            timeLeft = updateInterval;
            accum = 0.0f;
            frames = 0;
        }
    }
}
