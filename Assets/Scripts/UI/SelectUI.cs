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
    //시작 버튼을 눌렀을 때 솔로모드, 코옵모드(차후 추가 가능) 선택 가능
    //솔로모드에 커서를 가져다 댈 경우 최고점수가 보임

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
        int BestScore = PlayerPrefs.GetInt("BestScore", 0); // 저장된 최고 점수를 불러옵니다. 없으면 0을 반환합니다.
        BestScoreText.text = "Best Score: " + BestScore; // 최고 점수를 UI Text에 표시합니다.
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
