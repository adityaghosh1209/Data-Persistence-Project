using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private void Start()
    {
        Text text = this.gameObject.GetComponent<Text>();
        text.text = $"Best Score : {MainMenu.Instance.PlayerName} : {MainMenu.Instance.Highscore}";
    }
    
}
