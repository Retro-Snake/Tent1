using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLocation : MonoBehaviour
{
    private Collider2D colliderToCompare;

    public SwitchCamera cameraSwitcher;
    public int cameraIndexToSwitch; //Номер камеры на которую переключаемся
    public float animSec = 1f;
    public Animator transition;
    public string animName;
    void Start()
    {       
        colliderToCompare = GetComponent<Collider2D>();
        cameraSwitcher = FindObjectOfType<SwitchCamera>();
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

                if (colliderToCompare.OverlapPoint(touchPosition))  // Точка касания находится внутри коллайдера объекта
                {
                    
                    StartCoroutine(LoadAnim());
                }
            }
        }
    }


    IEnumerator LoadAnim()
    {
        
        if (transition != null && animName != (""))
        {
            transition.SetTrigger(animName);
                      
        }else
        {
            animSec = 0;
        }
        
        yield return new WaitForSeconds(animSec);
        cameraSwitcher.SwitchToCamera(cameraIndexToSwitch);
    }
}
