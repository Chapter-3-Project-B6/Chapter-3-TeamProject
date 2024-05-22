using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private string playerTag;


    public Transform Player { get; private set; }
    public TMP_Text player1ScoreText;

    public int Player1Score;

    
    public TextMeshProUGUI timeTxt;
    public TextMeshProUGUI PlayTime;
    private float Timer = 0f;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if(Player1Score < 0)
        {
            Player1Score = 0;
        }

        player1ScoreText.text = Player1Score.ToString("D6");

        Timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(Timer / 60F);
        int seconds = Mathf.FloorToInt(Timer % 60F);

        timeTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        PlayTime.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
