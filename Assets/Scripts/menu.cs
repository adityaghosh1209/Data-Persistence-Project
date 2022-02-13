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
public class menu : MonoBehaviour
{

    public Text GetText;
    public InputField GetInputField;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.Instance.LoadColor();
        GetText.text = $"{MainMenu.Instance.PlayerName} : {MainMenu.Instance.Highscore} ";
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ValueChangeCheck()
    {
        MainMenu.Instance.PlayerName = GetInputField.text; 
    }

    public void changescreen(int sceenenum)
    {
        SceneManager.LoadScene(sceenenum);
    }
    public void Exit()
    {
        MainMenu.Instance.saveplayerdata();
#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#else
            Application.Quit(); // original code to quit Unity player
#endif
    }
}
