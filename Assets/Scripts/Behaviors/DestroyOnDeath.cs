using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    private HealthSystem _healthSystem;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _healthSystem.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            // TODO: 적 기체에 따라 스코어 중가

        }

        _rigidbody.velocity = Vector2.zero;

        foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        {
            component.enabled = false;
        }

        Destroy(gameObject);
    }
}
