using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class NotificationInvoke : MonoBehaviour
{
    public Animator Notiff;
    public TextMeshProUGUI textPro;
    public float cloack=20f;
    public float IndexTimer = 5f;
    public float notTimer = 1f;
    private void Start()
    {
        Notiff = GetComponent<Animator>();
    }
    void Update()
    {
        if (cloack <= IndexTimer)
        {
            cloack += Time.deltaTime;
            NotifExit(cloack);
        }
        else
        {
            Notiff.ResetTrigger("Notification");
        }
    }
    public void NotifInvoke(string TextInNotif)
    {
        StartCoroutine(NotifInvokeCorutin(TextInNotif));        
    }
    public void NotifExit(float timerStop)
    {
        Notiff.SetFloat("Timer", timerStop);//������ �������� Float � ��������� ��� �������� ��������� ���� ����� ������ ��������������
    }

    public IEnumerator NotifInvokeCorutin(string TextInNotif)
    {
        yield return new WaitForSeconds(notTimer);
        Notiff.SetTrigger("Notification");
        textPro.text = TextInNotif;
        cloack = 0f;
    }
   
}
