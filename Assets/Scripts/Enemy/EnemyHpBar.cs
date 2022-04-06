using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    
    [SerializeField] private Enemy _enemy;
    private Slider _slider;

    public void Initializate(Enemy enemy)
    {
        _enemy = enemy;
        
        
    }

    void Start()
    {
        _slider = GetComponent<Slider>();
        SetMaxHealth();
    }

    void Update()
    {
        SetHealth();
        transform.position = Camera.main.WorldToScreenPoint(_enemy.transform.position)
            + new Vector3(0,15,0);
    }

    void SetMaxHealth()
    {
        _slider.maxValue = _enemy.MaxHp;
        SetHealth();
    }

    void SetHealth()
    {

        _slider.value = _enemy.Hp;

    }
}
