using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using System.Data;

public class SelectUI : MonoBehaviour
{
    //���� ��ư�� ������ �� �ַθ��, �ڿɸ��(���� �߰� ����) ���� ����
    //�ַθ�忡 Ŀ���� ������ �� ��� �ְ������� ����

    [SerializeField] private TextMeshProUGUI BestScoreText;
    public Sprite[] characterImages;
    public Image selectedCharacter;
    public AudioClip selectMenuBGM;

    private void Start()
    {
        LoadBestScore();
    }

    public void BottonClickSfx()
    {
        AudioManager.instance.PlaySFX("ButtonClick");
    }

    public void CharacterClickSfx()
    {
        AudioManager.instance.PlaySFX("SelectCharacterSFX");
    }

    public void SecelectMusicChange()
    {
        AudioManager.instance.PlayBGM(selectMenuBGM);
    }

    private void LoadBestScore()
    {
        int BestScore = PlayerPrefs.GetInt("BestScore", 0); // ����� �ְ� ������ �ҷ��ɴϴ�. ������ 0�� ��ȯ�մϴ�.
        BestScoreText.text = "Best Score: " + BestScore; // �ְ� ������ UI Text�� ǥ���մϴ�.
    }

    public void ChoiceCharacter(int num)
    {
        selectedCharacter.sprite = characterImages[num];
        DataManager.instance.characterNum = num;
        
    }

    public void GoBtn()
    {
        AudioManager.instance.StopBGM();
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
