using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private CharacterStatHandler _statHandler;

    public event Action<float> OnDamage;
    public event Action<float> OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;

    public float CurrentHealth { get; private set; }
    public float MaxHealth => _statHandler?.currentStat?.health ?? 0;

    private float _healthChangeDelay = 0.5f;
    private float _timeSinceLastChange = float.MaxValue;
    private bool _isAttacked = false;

    private void Awake()
    {
        _statHandler = GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
        CurrentHealth = _statHandler.currentStat.health;
    }

    private void Update()
    {
        if (_isAttacked)
        {
            _timeSinceLastChange += Time.deltaTime;
            if (_timeSinceLastChange >= _healthChangeDelay)
            {
                OnInvincibilityEnd?.Invoke();
                _isAttacked = false;
            }
        }
    }

    public bool ChangeHealth(float amount)
    {
        if (_isAttacked)
        {
            return false;
        }

        _timeSinceLastChange = 0f;
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        if (CurrentHealth <= 0f)
        {
            CallDeath();
            return true;
        }

        if (amount >= 0)
        {
            OnHeal?.Invoke(CurrentHealth);
        }
        else
        {
            OnDamage?.Invoke(CurrentHealth);
            _isAttacked = true;
        }

        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }
}
