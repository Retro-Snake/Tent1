using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundScript
{
    [Header("��� �������� ���������� ��� �������������")]
    public string name;
    [Header("���� �����")]
    public AudioClip clip;
    [Range(0f,1f)]
    [Header("���������")]
    public float volume;
    [Header("��� ���������")]
    [Range(0.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource sorce;
}
