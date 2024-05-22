using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private float delayTime = 1f;

    public void StartBtn()
    {
        AudioManager.instance.PlaySFX("ButtonClick");
        SceneManager.LoadScene("SelectScene");

    }

    public void ExitBtn()
    {
        //게임 종료
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit(); 최종버전
    }
}
