using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{

    public Enemy(int hp, float speed) : base(hp, speed)
    {
        Hp = hp;
        Speed = speed;
    }

    [SerializeField] float _obstacleDistance = 5f;
    [SerializeField] GameObject _prefabBullet;

    [SerializeField] int _damage = 10;
    [SerializeField] bool _canShoot;

    [SerializeField] int _maxHp;

    [SerializeField] GameObject _hpBarPrefab;
    GameObject _hpBar;
    
    void Start()
    {
        MaxHp = _maxHp;
        Hp = 100;
        CreateHpBar(_hpBarPrefab);

    }

    void Update()
    {
        

        Vector3 moveDirection = Vector3.forward * Speed * Time.deltaTime;
        transform.Translate(moveDirection);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.distance < _obstacleDistance)
            {
                float randomAngles = Random.Range(-100f, 100f);

                transform.Rotate(new Vector3(0,randomAngles,0));
            }
            if (hit.transform.gameObject.GetComponent<Player>())
            {
                Shoot(hit.point);
            }
        }
    }

    void Shoot(Vector3 targetPos)
    {
        GameObject prefabBullet = Instantiate(_prefabBullet, transform.position, Quaternion.identity);
        Bullet bullet = prefabBullet.GetComponent<Bullet>();

        bullet.Damage = _damage;
        Vector3 bulletMoveDirection = targetPos - transform.position;

        bullet.MoveDirection = bulletMoveDirection;
    }

    void CreateHpBar(GameObject prefabHpBar)
    {
        _hpBar = Instantiate(prefabHpBar, transform.position, Quaternion.identity);

        _hpBar.transform.SetParent(CanvasUI.transform);
        Enemy enemy = GetComponent<Enemy>();

        _hpBar.GetComponent<EnemyHpBar>().Initializate(enemy: enemy);
        
    }
    private void OnDestroy()
    {
        Destroy(_hpBar);
    }

}
