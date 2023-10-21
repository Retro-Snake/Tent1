using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuistLogic : MonoBehaviour
{
    public UpdateScore scoreUpdate; // вытаскиваем ScoreUpdate для 
    public int curscore;
    public int allscore;
    public float zNew;
    private Vector3 zOld;
    private Vector3 currentPosZ;
    public List<GameObject> QuestListObject;//Список Объектов что необходимы для прохождения квеста
    public List<GameObject> CurrentQuestListObject = new List<GameObject>();//Список выбранных объектов игроком уже,нужен для проверки

    private void Awake()
    {
        currentPosZ = transform.position;
        zOld = transform.position;
        scoreUpdate = FindObjectOfType<UpdateScore>();
        scoreUpdate.OnScoreChanged += MyCustomMetod;// Подписка на событие изменения количества щупалец и вызов метода
    }

    private void MyCustomMetod(int nowScore)// Приравниваем значение CurScore к актуальному количеству щупалец найденных
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
        //Проверка Если все тентакли найденны запуск предметов квеста
            //Уведомление о том что квест начался
            //

    }

    public void CorrectObjectCheck( GameObject gameObject)// Проверка на соответвие коллекций, добавлем и удаляем если объект уже был в нашейколлекции, если число объектов одного листа соответсвует второму проводим сравнение объектов в листах
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
            if (allObjectsSelected)//Если Листы одинаковые то появляется завершение квеста
            {

            }
        }
        
    }
        
        
 }
