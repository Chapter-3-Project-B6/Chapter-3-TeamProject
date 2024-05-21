using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private string playerTag;

    public Transform Player { get; private set; }
    public TMP_Text player1ScoreText;

    public int Player1Score;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    private void Update()
    {
        if(Player1Score < 0)
        {
            Player1Score = 0;
        }

        player1ScoreText.text = Player1Score.ToString("D6");
    }
}
