using UnityEngine;
using System.Threading;
using TMPro;
using UnityEngine.SceneManagement;

public class DestroyOnDeath : MonoBehaviour
{
    private HealthSystem _healthSystem;
    private Rigidbody2D _rigidbody;
    public GameObject endPanel;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _healthSystem.OnDeath += OnDeath;
    }

    public void OnDeath()
    {
        _rigidbody.velocity = Vector2.zero;

        foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        {
            component.enabled = false;
        }

        gameObject.SetActive(false);
        Destroy(gameObject);

        if (PlayerPrefs.HasKey("BestScore"))
        {
            int bestScore = PlayerPrefs.GetInt("BestScore");
            if (bestScore < GameManager.instance.Player1Score)
            {
                PlayerPrefs.SetInt("BestScore", GameManager.instance.Player1Score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", GameManager.instance.Player1Score);
        }

        Time.timeScale = 0f;
        endPanel.SetActive(true);


    }

}
