using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
using System;
#endif
public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance; //myself reffrence for others
    public string PlayerName; //whatever i want to store and retrieve
    public string Highscore = "0"; //whatever i want to store and retrieve
    
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        LoadColor();
    }
    

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public string Highscore;
    }

    public void saveplayerdata()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.Highscore = Highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            Highscore = data.Highscore;
        }
    }
    public void changescreen(int sceenenum)
    {
        SceneManager.LoadScene(sceenenum);
    }

    public void Exit()
    {
        
#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#else
            Application.Quit(); // original code to quit Unity player
#endif
    } 
}