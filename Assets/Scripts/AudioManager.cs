using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public SoundScript[] sounds;
    void Awake()
    {
        foreach(SoundScript s in sounds) 
        {            
            s.sorce = gameObject.AddComponent<AudioSource>();
            s.sorce.clip = s.clip;
            s.sorce.volume= s.volume;
            s.sorce.pitch= s.pitch;
         
        }
    }

    public void Play(string name)
    {
        SoundScript s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { return; }
        s.sorce.Play(); 
    }
}
