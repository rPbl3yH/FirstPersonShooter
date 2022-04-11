using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarBox : MonoBehaviour
{

    [SerializeField] private Target _target;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        _target.HealthPoint += OnDamageApply;
    }

    private void OnDestroy()
    {
        _target.HealthPoint -= OnDamageApply;
    }


    public void OnDamageApply(float percent)
    {
        _image.fillAmount = percent;
    }
}
