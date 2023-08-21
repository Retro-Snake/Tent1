using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLvlAnimation : MonoBehaviour
{
    public Button mainButton;
    public Button prevButton;
    public Button nextButton;

    private Vector3 defaultScale;

    private void Start()
    {
        defaultScale = mainButton.transform.localScale;
    }

    public void SetMainButton(Button newMainButton)
    {
        mainButton = newMainButton;
    }

    public void OnSwipedLeft()
    {
        mainButton.transform.localScale = defaultScale * 0.5f;
        nextButton.transform.localScale = defaultScale;
    }

    public void OnSwipedRight()
    {
        mainButton.transform.localScale = defaultScale * 0.5f;
        prevButton.transform.localScale = defaultScale;
    }

    public void OnReleased()
    {
        mainButton.transform.localScale = defaultScale;
        prevButton.transform.localScale = defaultScale;
        nextButton.transform.localScale = defaultScale;
    }
}
