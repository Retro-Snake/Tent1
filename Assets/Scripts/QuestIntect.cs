using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestIntect : MonoBehaviour
{
    private Collider2D colliderToCompare;
    //public GameObject objectToSwitch;
    public string soundName;
    private Vector3 previousPosition;
    private Camera CameraTran;
    private Vector3 cameraPreviousPosition; // ���������� ������� ������
    public SpriteRenderer rend;
    private Color StartColor;
    public Color SwitchColor;
    public GameObject SwitchObjectDOP;// ���� ����� �������� ��� ��������� �������������� ������


    public float interactIndex = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        StartColor = rend.color;
        colliderToCompare = GetComponent<Collider2D>();
        CameraTran = FindAnyObjectByType<Camera>();
        cameraPreviousPosition = CameraTran.transform.position;// �������������� ��������� ������� ������
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = CameraTran.transform.position;// ������� ������� ������
        float distance = Vector3.Distance(currentPosition, cameraPreviousPosition); // ���������� ����� ������� � ���������� ���������
        cameraPreviousPosition = currentPosition; // ��������� ���������� ������� ��� ���������� �����  
        if (distance < interactIndex)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                    RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                    if (hit.collider != null && hit.collider.gameObject == gameObject)
                    {
                        if(rend.color != SwitchColor )
                        {
                            rend.color = SwitchColor;
                            if (SwitchObjectDOP != null)
                            {
                                // SwitchObjectDOP.SetActive(!SwitchObjectDOP.activeSelf);
                                SwitchObjectDOP.SetActive(true);
                            }
                            
                        }
                        else
                        {
                            rend.color = StartColor;
                            if (SwitchObjectDOP != null)
                            {
                                //SwitchObjectDOP.SetActive(!SwitchObjectDOP.activeSelf); 
                                SwitchObjectDOP.SetActive(false);
                            }
                        }

                        FindObjectOfType<QuistLogic>().CorrectObjectCheck( gameObject);

                        FindObjectOfType<AudioManager>().Play(soundName);
                    }
                }

            }
        }
    }
}
