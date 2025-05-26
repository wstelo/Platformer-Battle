using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth = 100;

    public event Action <Health> HealthEnded;

    public float CurrentHealth { get; private set; }

    public void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void IncreaseHealth(float healthCount)
    {
        CurrentHealth += healthCount;

        if(CurrentHealth > _maxHealth)
        {
            CurrentHealth = _maxHealth;
        }

        Debug.Log($"Востановлено {healthCount} здоровья. Всего {CurrentHealth} здоровья");
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        Debug.Log($"Получил {damage} урона. Осталось {CurrentHealth} здоровья.");

        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            HealthEnded?.Invoke(this);
        }
    }
}
