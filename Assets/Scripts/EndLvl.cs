using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLvl : MonoBehaviour
{
    public UpdateScore scoreUpdate; // ����������� ScoreUpdate ��� 
    public int scoreEnd;// ���������� ����� ��� ����������� 
    public float endWait;// ����� �������� 
    public string notifEndText = "����";

    private void Start()
    {
        scoreUpdate = FindObjectOfType<UpdateScore>();
        scoreUpdate.OnScoreChanged += CheckCurrScore;// �������� �� ������� ��������� ���������� ������� � ����� ������
    }

    private void CheckCurrScore(int curScore)
    {
        
        if (curScore >= scoreEnd)
        {
            if (FindObjectOfType<NotificationInvoke>() != null)
            {
                Debug.Log("����� EndNotif");
                FindObjectOfType<NotificationInvoke>().NotifInvoke(notifEndText);
            }
            //StartCoroutine(EndNotif());
        }
    }

    /*private IEnumerator EndNotif()
    {
        yield return new WaitForSeconds(endWait);
        if (FindObjectOfType<NotificationInvoke>() != null)
        {
            FindObjectOfType<NotificationInvoke>().NotifInvoke(notifEndText);
        }
    }*/
}
