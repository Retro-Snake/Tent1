using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static SaveManager.Save;



public class SaveManager : MonoBehaviour
{
    
    [Header("��� ����������.")]
    public string progressFileName ;
    private string progressFilePath;
    
    public List<GameObject> TentSaveList= new List<GameObject>();

    [Header("��� ����� ������� ����� �������� ��� ������� �����")]
    public string soundName;

    private void Start()
    {
        progressFileName = progressFileName + ".dat";
        progressFilePath = Path.Combine(Application.persistentDataPath, progressFileName);
        FindObjectOfType<AudioManager>().Play(soundName);
    }


    public void SaveGame ()
    {
         BinaryFormatter bf = new BinaryFormatter();
         FileStream fs = new FileStream(progressFilePath,FileMode.Create);

        Save save = new Save();

        save.SaveTent(TentSaveList);

        bf.Serialize(fs, save);
        fs.Close();

    }   
    public void LoadGame()
    {
        if (!File.Exists(progressFilePath))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(progressFilePath,FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);
        fs.Close();


        int i = 0;
        foreach(var tent in save.TentData)
        {

            TentSaveList[i].GetComponent<TouchImpact>().LoadData(tent);
            i++;
        }
    }

    [System.Serializable]
    public class Save
    {
        [System.Serializable]
        public class ColarTent
        { 
            public float r, g, b, a;

            public ColarTent(Color color)
            {
                r = color.r;
                g = color.g;
                b = color.b;
                a = color.a;
            }
        }
        [System.Serializable]
        public struct TentSaveData
        {
            public ColarTent TentColor;

            public TentSaveData(Color color)
            {
                TentColor = new ColarTent(color);;
            }
        }

        public List<TentSaveData> TentData = new List<TentSaveData>();

        public void SaveTent(List<GameObject> objects) 
        { 
             foreach (var go in objects) 
            {
                var touchImpact = go.GetComponent<TouchImpact>();

                Color color = touchImpact.rend.color;

                TentData.Add(new TentSaveData(color));
            }
        }
    }

    public void ResetGame()
    {
        // ���������� ��������� �������� � �������� ��������
        foreach (var tent in TentSaveList)
        {
            tent.GetComponent<TouchImpact>().ResetToDefault();
        }

        // ������� ���� ����������
        if (File.Exists(progressFilePath))
        {
            File.Delete(progressFilePath);
            Debug.Log("���������� �������.");
        }
        else
        {
            Debug.LogWarning("���� ���������� �� ������.");
        }
    }


}
