using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SaveManager;
using static UnityEngine.GraphicsBuffer;
using System.IO;
using System;

public class TouchImpact : MonoBehaviour
{
    public SpriteRenderer rend ;
    public Color newColor;
    private Color StartColor;
    public UpdateScore scoreUpdate;
    private Collider2D colliderToCompare;
    private SaveManager progressManager;
    private Vector3 previousPosition;
    private Camera CameraTran;
    private Vector3 cameraPreviousPosition; // ���������� ������� ������
    public string soundName;
    public float interactFloat = 0.003f;

    

    void Start()    
    {
        rend = GetComponent<SpriteRenderer>();
        colliderToCompare = GetComponent<Collider2D>();
        progressManager = FindObjectOfType<SaveManager>();
        scoreUpdate = FindObjectOfType<UpdateScore>();
        StartColor = rend.color;
        CameraTran = FindAnyObjectByType<Camera>();
        cameraPreviousPosition = CameraTran.transform.position;// �������������� ��������� ������� ������
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = CameraTran.transform.position;// ������� ������� ������
        float distance = Vector3.Distance(currentPosition, cameraPreviousPosition); // ���������� ����� ������� � ���������� ���������
        
        cameraPreviousPosition = currentPosition; // ��������� ���������� ������� ��� ���������� �����  
        if (distance < interactFloat)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                    RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);                    
                    if ((!ColorEqualsIgnoreAlpha(rend.color,newColor)) && (hit.collider != null) && (hit.collider.gameObject == gameObject))
                    {
                        UpdateColor(newColor);
                        // ����� ������� ��������� ������ ���������� �������
                        Debug.Log("���� ������� � �������:" + gameObject.name);

                        scoreUpdate.UpdateNumberText(progressManager.progressFileName, 1);// ���������� ��������� �����
                        progressManager.SaveGame();
                        FindObjectOfType<AudioManager>().Play(soundName);// �������� ���� � �������� soundName �� ���� ���������
                        /*if (FindObjectOfType<NotificationInvoke>() != null)
                        {
                            FindObjectOfType<NotificationInvoke>().NotifInvoke(("���� ������� � �������:" + gameObject.name).ToString());
                        }*/ // ����� ���� ��� ������ ��� ����������� � ���� 
                    }
                }
            }
        }
    }
    bool ColorEqualsIgnoreAlpha(Color32 color1, Color32 color2)
    {
        return color1.r == color2.r && color1.g == color2.g && color1.b == color2.b;
    }

    private void UpdateColor(Color color)
    {        
        rend.color = color;
        
    }

    public void ResetToDefault()
    {
        // ��������������� �������� ����
        UpdateColor(StartColor);
        scoreUpdate.UpdateNumberText(progressManager.progressFileName,-1);
        Debug.Log("ResetLog" + PlayerPrefs.HasKey(progressManager.progressFileName));
    }

    public void LoadData(Save.TentSaveData save)
    {
        rend.color = new Color (save.TentColor.r, save.TentColor.g,save.TentColor.b,save.TentColor.a);
        scoreUpdate.LoadScore(progressManager.progressFileName);
    }


}
