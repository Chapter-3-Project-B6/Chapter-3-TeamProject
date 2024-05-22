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
        AudioManager.instance.PlaySFX("ButtonClickSFX");
        SceneManager.LoadScene("SelectScene");

    }

    public void ExitBtn()
    {
        //���� ����
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit(); ��������
    }
}
