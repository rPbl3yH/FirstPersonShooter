using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 3f;
    private Vector3 _moveDirection;

    public int Damage;

    public Vector3 MoveDirection { get => _moveDirection; set => _moveDirection = value; }

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Meet object");
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.TakeDamage(Damage);
            player.Info();
            
        }
        Destroy(gameObject);
    }


}
