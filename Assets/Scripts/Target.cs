using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] public int MaxHp = 50;
    private int _currentHp;

    public event Action<float> HealthPoint;

    private void Awake()
    {
        _currentHp = MaxHp;
    }

    private void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        _currentHp -= damage;
        if(_currentHp <= 0)
        {
            Die();
        }
        else
        {
            float HealthInPercent = (float)_currentHp / MaxHp;
            HealthPoint?.Invoke(HealthInPercent);
        }
    }

    private void Die()
    {

        Destroy(gameObject);
    }
}
