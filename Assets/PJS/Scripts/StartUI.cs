using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void StartBtn()
    {
        //���� ��ư�� ������ �� �ַθ��, �ڿɸ��(���� �߰� ����) ���� ����, �ַθ�忡 Ŀ���� ������ �� ��� �ְ������� ����
        SceneManager.LoadScene("SelectScene");
    }

    public void ExitBtn()
    {
        //���� ����
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit(); ��������
    }
}
