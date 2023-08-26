using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundScript
{
    [Header("Имя звуковой переменной для использования")]
    public string name;
    [Header("Файл звука")]
    public AudioClip clip;
    [Range(0f,1f)]
    [Header("Громкость")]
    public float volume;
    [Header("Шаг громкости")]
    [Range(0.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource sorce;
}
