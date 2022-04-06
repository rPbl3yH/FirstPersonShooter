using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    

    public Character(int hp, float speed)
    {
        Hp = hp;
        Speed = speed;
    }

    public float Speed;
    public int Hp;
    public int MaxHp;

    public Canvas CanvasUI;

    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        { 
            CharacterDestroy();
        }
    }

    public void CharacterDestroy()
    {
        Destroy(gameObject);
    }

    public void Info()
    {
        Debug.Log($"Name: {gameObject.name} " +
            $"HP: {Hp}");
    }

    
}
