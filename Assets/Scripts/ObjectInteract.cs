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

    // Start is called before the first frame update
    void Start()
    {
        colliderToCompare = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
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

   
