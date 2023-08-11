using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLocation : MonoBehaviour
{
    public GameObject TEst;
    private Collider2D colliderToCompare;
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

                if (colliderToCompare.OverlapPoint(touchPosition))
                {

                    //gameObject.SetActive(true);

                    TEst.SetActive(false);

                    // Точка касания находится внутри коллайдера объекта
                    Debug.Log(":" + gameObject.name);
                }
            }
        }
    }
}
