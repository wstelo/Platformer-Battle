using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponCollisionDetector))]

public class Sword : Weapon
{
    [SerializeField] private float _damage = 10;

    private WeaponCollisionDetector _weaponCollisionDetector;

    public float Damage { get; private set; }

    public void Awake()
    {
        _weaponCollisionDetector = GetComponent<WeaponCollisionDetector>();
        Damage = _damage;
    }

    private void OnEnable()
    {
        _weaponCollisionDetector.TargetDetected += ApplyDamage;
    }

    private void OnDisable()
    {
        _weaponCollisionDetector.TargetDetected -= ApplyDamage;
    }

    private void ApplyDamage(IDamageable target)
    {
        target.TakeDamage(Damage);
    }
}
