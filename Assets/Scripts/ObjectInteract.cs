using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.PlayerLoop.EarlyUpdate;
using System.IO;
using UnityEngine.Audio;

public class ObjectInteract : MonoBehaviour
{
    private Collider2D colliderToCompare;
    public GameObject objectToSwitch;
    public string soundName;
    private Vector3 previousPosition;
    private Camera CameraTran;
    private Vector3 cameraPreviousPosition; // ���������� ������� ������

    public float interactIndex = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
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
                        gameObject.SetActive(false);
                        if (objectToSwitch != null)
                        {
                            objectToSwitch.SetActive(true);
                        }
                        FindObjectOfType<AudioManager>().Play(soundName);
                    }
                }

            }
        }
        }
}

   
