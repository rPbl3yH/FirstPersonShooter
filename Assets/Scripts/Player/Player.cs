using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    

    [SerializeField] CharacterController _controller;

    private float _gravity = -9.8f;
    private float _directionZ;

    public Player(int hp, float speed) : base(hp, speed)
    {
        Speed = speed;
        Hp = hp;
        
    }
    private void Awake()
    {
        Hp = 100;
        MaxHp = 100;
    }

    void Start()
    {
        
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        float deltaX = Input.GetAxis("Horizontal") * Speed;
        float deltaZ = Input.GetAxis("Vertical") * Speed;



        Vector3 moveDirection = new Vector3(deltaX, 0, deltaZ);
        moveDirection = Vector3.ClampMagnitude(moveDirection, Speed) * Time.deltaTime;
        moveDirection.y = _gravity;

        moveDirection = transform.TransformDirection(moveDirection);
        
        _controller.Move(moveDirection);
    }

    
}
