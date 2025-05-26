using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollisionDetector : MonoBehaviour
{
    public event Action<IDamageable> TargetDetected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out IDamageable target) )
        {
            TargetDetected?.Invoke(target);
        }
    }
}
