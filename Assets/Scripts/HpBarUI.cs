using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _textHp;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _slider = GetComponentInChildren<Slider>();
        _textHp = GetComponentInChildren<Text>();

        SetMaxHealth();
    }

    void Update()
    {
        SetHealth();
        _textHp.text = $"{_player.Hp} / {_player.MaxHp}";
    }

    void SetMaxHealth()
    {
        _slider.maxValue = _player.MaxHp;
        SetHealth();
    }

    void SetHealth()
    {
        
        _slider.value = _player.Hp;
        
    }
}
