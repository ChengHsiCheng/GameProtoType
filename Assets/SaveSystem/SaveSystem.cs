using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using LitJson;

public class SaveSystem : MonoBehaviour
{
    static string savePath;
    public static List<MainSaveData> mainSaveData = new List<MainSaveData>();
    public static int GetData(string saveString)
    {
        MainSaveData data = mainSaveData.Find(d => d.saveString == saveString);

        if (data == null)
        {
            return 0;
        }

        return data.saveInt;

    }

    public static void DeleteData(int i)
    {
        switch (i)
        {
            case 0:
                File.Delete(savePath + "/AllSaveData00.json");
                break;
            case 1:
                File.Delete(savePath + "/AllSaveData01.json");
                break;
            case 2:
                File.Delete(savePath + "/AllSaveData02.json");
                break;
            default:
                Debug.Log("A");
                break;
        }
    }

    public static void SaveData(string saveString, int saveInt, int i)
    {
        savePath = Application.dataPath + "/AllDatas";

        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }

        MainSaveData existingData = mainSaveData.Find(data => data.saveString == saveString);

        if (existingData != null)
        {
            existingData.saveInt = saveInt;
        }
        else
        {
            MainSaveData newSaveData = new MainSaveData
            {
                saveString = saveString,
                saveInt = saveInt
            };
            mainSaveData.Add(newSaveData);
        }
        string json = JsonMapper.ToJson(mainSaveData);


        switch (i)
        {
            case 0:
                File.WriteAllText(savePath + "/AllSaveData00.json", json);
                break;
            case 1:
                File.WriteAllText(savePath + "/AllSaveData01.json", json);
                break;
            case 2:
                File.WriteAllText(savePath + "/AllSaveData02.json", json);
                break;
            default:
                Debug.Log("A");
                break;
        }
    }
    public static void LoadData(int i)
    {
        bool isExist = false;

        savePath = Application.dataPath + "/AllDatas";
        if (Directory.Exists(savePath))
        {
            string files = "";

            switch (i)
            {
                case 0:
                    isExist = File.Exists(savePath + "/AllSaveData00.json");
                    Debug.Log(isExist + " " + i);
                    if (isExist)
                        files = savePath + "/AllSaveData00.json";
                    break;
                case 1:
                    isExist = File.Exists(savePath + "/AllSaveData01.json");
                    Debug.Log(isExist + " " + i);
                    if (isExist)
                        files = savePath + "/AllSaveData01.json";
                    break;
                case 2:
                    isExist = File.Exists(savePath + "/AllSaveData02.json");
                    Debug.Log(isExist + " " + i);
                    if (isExist)
                        files = savePath + "/AllSaveData02.json";
                    break;
                default:
                    break;
            }

            if (isExist)
            {
                string json = File.ReadAllText(files);
                List<MainSaveData> loadedData = JsonMapper.ToObject<List<MainSaveData>>(json);

                if (loadedData != null)
                {
                    mainSaveData = loadedData;
                }

                return;
            }

            mainSaveData.Clear();
        }
    }

}


[Serializable]
public class MainSaveData
{
    public string saveString;
    public int saveInt;
}


