using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] public int Damage;
    [SerializeField] private float _reloadTime;
    [SerializeField] private int countAmmo;

    [SerializeField] public ParticleSystem Particle;

    private void Awake()
    {
        Particle = GetComponentInChildren<ParticleSystem>();
    }

    private void Reload()
    {

    }

    public void Shoot()
    {

    }
}
