using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatSprite : MonoBehaviour
{
    public Sprite[] sprites; // ������ �� ���������

    void Start()
    {
        // �������� GameObjects � SpriteRenderer ��� ������� �������
        foreach (Sprite sprite in sprites)
        {
            GameObject spriteObject = new GameObject(sprite.name);
            SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
        }
    }
}
