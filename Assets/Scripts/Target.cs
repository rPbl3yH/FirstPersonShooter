using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int _hp = 50;

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if(_hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

        Destroy(gameObject);
    }
}
