﻿using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneUI : DestroyOnDeath
{
    public static GameManager instance;
    
    [SerializeField] public TMP_Text player1ScoreText;
    public int Player1Score;

    [SerializeField] private TextMeshProUGUI BestScoreTxt;


    public void BestScore()
    {
     int BestScore = PlayerPrefs.GetInt("BestScore", 0); // 저장된 최고 점수를 불러옵니다. 없으면 0을 반환합니다.
     BestScoreTxt.text = "Best Score: " + BestScore; // 최고 점수를 UI Text에 표시합니다.
    }

    public void NowScore()
    {
     player1ScoreText.text = Player1Score.ToString("D6"); // 현재 점수를 UI Text에 표시합니다.
    }


    public void MenuBtn()
    {
     AudioManager.instance.StopBGM();
     SceneManager.LoadScene("StartScene");
    }

    public void RetyrBtn()
    {
     AudioManager.instance.StopBGM();
     SceneManager.LoadScene("SelectScene");
    }

    
}



