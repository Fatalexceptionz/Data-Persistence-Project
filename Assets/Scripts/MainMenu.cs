using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        string name = Persistence.Instance.highScorePlayerName;
        int score = Persistence.Instance.highScore;

        Text text = GameObject.Find("BestScore").GetComponent<Text>();

        text.text = $"Best Score : {name} : {score}";

    }


    public void StartGame()
    {
        string text = GameObject.Find("PlayerName").GetComponent<InputField>().text;
        Persistence.Instance.playerName = text;

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
