using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{

    private bool volumeOnOffIndex;
    private Image image;
    public Sprite normalSprite; // Обычный спрайт
    public Sprite crossedSprite; // Спрайт с перечеркнутой иконкой
    public GameObject soundSpriteObject; // Игровой объект на котором будут спрайты 
    
    // Start is called before the first frame update
    void Start()
    {
        image = soundSpriteObject.GetComponent<Image>();
        int sondIndx = PlayerPrefs.GetInt("SoundIndex",2);
        if (sondIndx != 2)
        {
            if (sondIndx == 0) { volumeOnOffIndex = true; VolumeSet(); }
            else if (sondIndx == 1) { volumeOnOffIndex = false; VolumeSet(); }
        }
    }

    // Update is called once per frame
    public void VolumeSet()
    {
        if (volumeOnOffIndex == true)
        {
            image.sprite = crossedSprite;
            AudioListener.volume = 0;
            volumeOnOffIndex = false;
            PlayerPrefs.SetInt("SoundIndex", 0);
        }
        else if (volumeOnOffIndex == false) 
        {
            image.sprite = normalSprite;
            AudioListener.volume = 1;
            volumeOnOffIndex = true;
            PlayerPrefs.SetInt("SoundIndex", 1);
        }


    }
}
