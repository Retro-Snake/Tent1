using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuistLogic : MonoBehaviour
{
    public UpdateScore scoreUpdate; // ����������� ScoreUpdate ��� 
    public int curscore;
    public int allscore;
    public float zNew;
    private bool chekQuestIndex = true; // True = ������ ����������� ����� �������. False = ������ ����������� �� ���� ������� ��� ����
    private Vector3 zOld;
    private Vector3 currentPosZ;
    public GameObject questGameObject;// ������� ������ ������� �������� � ���� �������� , ��� ������ �������� �� ���������� ������
    public GameObject fonZadnik; // �������� ��� ����� ����������� �������� �������
    [Header("������ �������� ��� ���������� ��� ����������� ������")]
    public List<GameObject> QuestListObject;//������ �������� ��� ���������� ��� ����������� ������
    private List<GameObject> CurrentQuestListObject = new List<GameObject>();//������ ��������� �������� ������� ���,����� ��� ��������
    [Header("��������� � ������ ������")]
    public string questNowNotif;
    [Header("��������� ������������� ������")]
    public List<string> QuestInvokeList = new List<string>();
    [Header("��������� ������������ ������")]
    public List<string> QuestBadInvokeList = new List<string>();

    private void Awake()
    {
        currentPosZ = transform.position;
        questGameObject.transform.position = currentPosZ;
        zOld = transform.position;

        scoreUpdate = FindObjectOfType<UpdateScore>();
        scoreUpdate.OnScoreChanged += MyCustomMetod;// �������� �� ������� ��������� ���������� ������� � ����� ������
    }

    private void MyCustomMetod(int nowScore)// ������������ �������� CurScore � ����������� ���������� ������� ���������
    {
        //�������� ���� ��� �������� �������� ������ ��������� ������
        curscore = nowScore;

        if (curscore >= allscore) 
        {
            currentPosZ.z = zNew;
            transform.position = currentPosZ;
            //����������� � ��� ��� ����� �������
            if (FindObjectOfType<NotificationInvoke>() != null && chekQuestIndex == true)
            {
                FindObjectOfType<NotificationInvoke>().NotifInvoke(questNowNotif);
                chekQuestIndex = false;
                Debug.Log("�� ��� 1");
            }
            fonZadnik.SetActive(false);
        }
        else
        {
            transform.position = zOld;
            questGameObject.transform.position = zOld;
            chekQuestIndex = true;
            fonZadnik.SetActive(true);
        }      
        
    }

    public void CorrectObjectCheck( GameObject gameObject)// �������� �� ���������� ���������, �������� � ������� ���� ������ ��� ��� � ��������������, ���� ����� �������� ������ ����� ������������ ������� �������� ��������� �������� � ������
    {
        if(!CurrentQuestListObject.Contains(gameObject)) 
        {
         CurrentQuestListObject.Add(gameObject);
        }else
        {
         CurrentQuestListObject.Remove(gameObject);
        }

        if(CurrentQuestListObject.Count == QuestListObject.Count) 
        {
            bool allObjectsSelected = true;
            foreach (GameObject QuestObject in QuestListObject)
            {
                if(!CurrentQuestListObject.Contains(QuestObject)) 
                {
                    if (FindObjectOfType<NotificationInvoke>() != null)
                    {
                        FindObjectOfType<NotificationInvoke>().NotifInvoke(GetRandomPhrase(QuestBadInvokeList));
                    }
                    allObjectsSelected = false;
                    break;
                }
            }
            if (allObjectsSelected)//���� ����� ���������� �� ���������� ���������� ������
            {
                questGameObject.transform.position = currentPosZ;
                if (FindObjectOfType<NotificationInvoke>() != null)
                {
                    FindObjectOfType<NotificationInvoke>().NotifInvoke(GetRandomPhrase(QuestInvokeList));
                }

            }
        }        
    }
     
    
    string GetRandomPhrase(List<string> phraseList) // ����� ������ �������� ����� �� ������, ������� �� ������� � ������ �����
    {
        if (phraseList.Count == 0)
        {
            return "������ ���� ����";
        }

        int randomIndex = Random.Range(0, phraseList.Count);
        return phraseList[randomIndex];
    }
        
 }
