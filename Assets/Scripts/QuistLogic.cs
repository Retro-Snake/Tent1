using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuistLogic : MonoBehaviour
{
    public UpdateScore scoreUpdate; // ����������� ScoreUpdate ��� 
    public int curscore;
    public int allscore;
    public float zNew;
    public float yBack;
    private bool chekQuestIndex = true; // True = ������ ����������� ����� �������. False = ������ ����������� �� ���� ������� ��� ����
    private Vector3 zOld;
    private Vector3 currentPosZ;
    private Vector3 yBC;
    public GameObject questGameObject;// ������� ������ ������� �������� � ���� �������� , ��� ������ �������� �� ���������� ������
    public GameObject fonZadnik; // �������� ��� ����� ����������� �������� �������
    [Header("������ �������� ��� ���������� ��� ����������� ������")]
    public List<GameObject> QuestListObject;//������ �������� ��� ���������� ��� ����������� ������
    public List<GameObject> CurrentQuestListObject = new List<GameObject>();//������ ��������� �������� ������� ���,����� ��� ��������
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
        yBC.y = yBack;
        zOld = transform.position;
        questGameObject.transform.position = yBC;
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
            ActivateChildrenRecursively(fonZadnik.transform, false);
        }
        else
        {
            transform.position = zOld;
            questGameObject.transform.position = zOld;
            chekQuestIndex = true;
            ActivateChildrenRecursively(fonZadnik.transform, true);                        
            Debug.Log("�� ��� 55");
        }      
        
    }

    void ActivateChildrenRecursively(Transform parent,bool checkBool)
    {
        // ���������� ������� �������� ������
        parent.gameObject.SetActive(checkBool);

        // ���������� �� ���� �������� �������� �������� ������� � ���������� �� ����������
        foreach (Transform child in parent)
        {
            ActivateChildrenRecursively(child, checkBool);
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
        if(CurrentQuestListObject.Count < QuestListObject.Count)
        {
            Debug.Log("������ � ��������1");           
            questGameObject.transform.position = yBC;
        }else if(CurrentQuestListObject.Count == QuestListObject.Count) 
         {
            Debug.Log("������ � ��������");
            bool allObjectsSelected = true;
            foreach (GameObject QuestObject in QuestListObject)
            {
                Debug.Log("������ �������� ������� ������");
                if (!CurrentQuestListObject.Contains(QuestObject)) 
                {
                    if (FindObjectOfType<NotificationInvoke>() != null)
                    {
                        FindObjectOfType<NotificationInvoke>().NotifInvoke(GetRandomPhrase(QuestBadInvokeList));
                    }
                    questGameObject.transform.position = zOld;
                    allObjectsSelected = false;
                    break;
                }
            }
            if (allObjectsSelected)//���� ����� ���������� �� ���������� ���������� ������
            {
                Debug.Log("��� ����� ������� � ���������� ��������");
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
