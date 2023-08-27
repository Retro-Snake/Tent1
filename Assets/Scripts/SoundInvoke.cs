using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInvoke : MonoBehaviour
{
    [Header("��� ����� ������� ����� �������� ��� ������� �������")]
    public string soundName;
    [Header("�������� �������")]
    public float delSec;
    void Start()
    {
        StartCoroutine(SoundStartDelayed(delSec));
    }

    public IEnumerator SoundStartDelayed(float delaySeconds)
    {
        Debug.Log("Before WaitForSeconds");
        yield return new WaitForSeconds(delaySeconds);
        Debug.Log("After WaitForSeconds, delayed method is called");
        FindObjectOfType<AudioManager>().Play(soundName);
    }
}
