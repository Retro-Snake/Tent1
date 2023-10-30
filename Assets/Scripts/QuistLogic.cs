using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuistLogic : MonoBehaviour
{
    public UpdateScore scoreUpdate; // вытаскиваем ScoreUpdate для 
    public int curscore;
    public int allscore;
    public float zNew;
    public float yBack;
    private bool chekQuestIndex = true; // True = первое уведомление можно пускать. False = первое уведомление не надо пускать уже было
    private Vector3 zOld;
    private Vector3 currentPosZ;
    private Vector3 yBC;
    public GameObject questGameObject;// Игровой объект который содержит в себе предметы , что должны появится по завершению квеста
    public GameObject fonZadnik; // Заглушка что будет перекрывать визально предмет
    [Header("Список Объектов что необходимы для прохождения квеста")]
    public List<GameObject> QuestListObject;//Список Объектов что необходимы для прохождения квеста
    public List<GameObject> CurrentQuestListObject = new List<GameObject>();//Список выбранных объектов игроком уже,нужен для проверки
    [Header("Сообщение О начале квеста")]
    public string questNowNotif;
    [Header("Сообщение положительное Первое")]
    public List<string> QuestInvokeList = new List<string>();
    [Header("Сообщение отрицательно Второе")]
    public List<string> QuestBadInvokeList = new List<string>();

    private void Awake()
    {
        currentPosZ = transform.position;
        questGameObject.transform.position = currentPosZ;
        yBC.y = yBack;
        zOld = transform.position;
        questGameObject.transform.position = yBC;
        scoreUpdate = FindObjectOfType<UpdateScore>();
        scoreUpdate.OnScoreChanged += MyCustomMetod;// Подписка на событие изменения количества щупалец и вызов метода
    }

    private void MyCustomMetod(int nowScore)// Приравниваем значение CurScore к актуальному количеству щупалец найденных
    {
        //Проверка Если все тентакли найденны запуск предметов квеста
        curscore = nowScore;

        if (curscore >= allscore) 
        {
            currentPosZ.z = zNew;
            transform.position = currentPosZ;
            //Уведомление о том что квест начался
            if (FindObjectOfType<NotificationInvoke>() != null && chekQuestIndex == true)
            {
                FindObjectOfType<NotificationInvoke>().NotifInvoke(questNowNotif);
                chekQuestIndex = false;
                Debug.Log("Мы тут 1");
            }
            ActivateChildrenRecursively(fonZadnik.transform, false);
        }
        else
        {
            transform.position = zOld;
            questGameObject.transform.position = zOld;
            chekQuestIndex = true;
            ActivateChildrenRecursively(fonZadnik.transform, true);                        
            Debug.Log("Мы тут 55");
        }      
        
    }

    void ActivateChildrenRecursively(Transform parent,bool checkBool)
    {
        // Активируем текущий дочерний объект
        parent.gameObject.SetActive(checkBool);

        // Проходимся по всем дочерним объектам текущего объекта и активируем их рекурсивно
        foreach (Transform child in parent)
        {
            ActivateChildrenRecursively(child, checkBool);
        }
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
        if(CurrentQuestListObject.Count < QuestListObject.Count)
        {
            Debug.Log("попали в проверку1");           
            questGameObject.transform.position = yBC;
        }else if(CurrentQuestListObject.Count == QuestListObject.Count) 
         {
            Debug.Log("попали в проверку");
            bool allObjectsSelected = true;
            foreach (GameObject QuestObject in QuestListObject)
            {
                Debug.Log("сейчас щупальца трогать нельзя");
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
            if (allObjectsSelected)//Если Листы одинаковые то появляется завершение квеста
            {
                Debug.Log("Тут квест пройден и появляются щупальца");
                questGameObject.transform.position = currentPosZ;
                if (FindObjectOfType<NotificationInvoke>() != null)
                {
                    FindObjectOfType<NotificationInvoke>().NotifInvoke(GetRandomPhrase(QuestInvokeList));
                }

            }
         }        
    }
     
    
    string GetRandomPhrase(List<string> phraseList) // Метод выбора случайно фразы из списка, который мы передаём в данный метод
    {
        if (phraseList.Count == 0)
        {
            return "Список фраз пуст";
        }

        int randomIndex = Random.Range(0, phraseList.Count);
        return phraseList[randomIndex];
    }
        
 }
