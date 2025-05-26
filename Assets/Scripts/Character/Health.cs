using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxValue = 100;

    private float _minValue = 0;

    public event Action <Health> HealthEnded;

    public float CurrentValue { get; private set; }

    public void Awake()
    {
        CurrentValue = _maxValue;
    }

    public void IncreaseHealth(float count)
    {   
        if(count > 0)
        {
            CurrentValue += count;
            CurrentValue = Mathf.Clamp(CurrentValue, _minValue, _maxValue);

            Debug.Log($"������������ {count} ��������. ����� {CurrentValue} ��������");
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            CurrentValue -= damage;
            Debug.Log($"������� {damage} �����. �������� {CurrentValue} ��������.");

            if (CurrentValue <= 0)
            {
                CurrentValue = 0;
                HealthEnded?.Invoke(this);
            }
        }
    }
}
