using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuistLogic : MonoBehaviour
{
    public UpdateScore scoreUpdate; // ����������� ScoreUpdate ��� 
    public int curscore;
    public int allscore;
    public float zNew;
    private Vector3 zOld;
    private Vector3 currentPosZ;
    public List<GameObject> QuestListObject;//������ �������� ��� ���������� ��� ����������� ������
    public List<GameObject> CurrentQuestListObject = new List<GameObject>();//������ ��������� �������� ������� ���,����� ��� ��������

    private void Awake()
    {
        currentPosZ = transform.position;
        zOld = transform.position;
        scoreUpdate = FindObjectOfType<UpdateScore>();
        scoreUpdate.OnScoreChanged += MyCustomMetod;// �������� �� ������� ��������� ���������� ������� � ����� ������
    }

    private void MyCustomMetod(int nowScore)// ������������ �������� CurScore � ����������� ���������� ������� ���������
    {
        curscore = nowScore;

        if (curscore >= allscore) 
        {
            currentPosZ.z = zNew;
            transform.position = currentPosZ;
        }else
        {
            transform.position = zOld;
        }
        //�������� ���� ��� �������� �������� ������ ��������� ������
            //����������� � ��� ��� ����� �������
            //

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
                    allObjectsSelected = false;
                    break;
                }
            }
            if (allObjectsSelected)//���� ����� ���������� �� ���������� ���������� ������
            {

            }
        }
        
    }
        
        
 }
