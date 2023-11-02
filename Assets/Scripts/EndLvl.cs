using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLvl : MonoBehaviour
{
    public UpdateScore scoreUpdate; // вытаскиваем ScoreUpdate для 
    public int scoreEnd;// Количество очков для заверешения 
    public float endWait;// Время задержки 
    public string notifEndText = "Тест";

    private void Start()
    {
        scoreUpdate = FindObjectOfType<UpdateScore>();
        scoreUpdate.OnScoreChanged += CheckCurrScore;// Подписка на событие изменения количества щупалец и вызов метода
    }

    private void CheckCurrScore(int curScore)
    {
        
        if (curScore >= scoreEnd)
        {
            if (FindObjectOfType<NotificationInvoke>() != null)
            {
                Debug.Log("Вызов EndNotif");
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
