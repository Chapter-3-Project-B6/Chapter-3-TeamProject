using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class SelectUI : MonoBehaviour
{
    //���� ��ư�� ������ �� �ַθ��, �ڿɸ��(���� �߰� ����) ���� ����, �ַθ�忡 Ŀ���� ������ �� ��� �ְ������� ����

    public void SoloModeBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void CoOpBtn()
    {

    }

    public void StartSceneBtn()
    {
        SceneManager.LoadScene("StartScene");
    }

    

}
