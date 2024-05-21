using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private string playerTag;

    public Transform player { get; private set; }
    public Text Player1ScoreText;

    public int Player1Score;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    private void Update()
    {
        Player1ScoreText.text = Player1Score.ToString("D6");
    }
}
