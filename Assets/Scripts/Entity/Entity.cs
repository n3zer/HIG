using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _armor;

    private bool _isTakeDamage;

    private Animator _animator;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate() => SetAnimation();

    private void SetAnimation()
    {
        _animator.SetBool("isTakeDamage", _isTakeDamage);
    }

    public void TakeDamage(float damage)
    {
        StartCoroutine(DamageAnimation());
        _health -= damage / (0.55f * _armor);
        if (_health <= 0)
            Destroy(gameObject);
    }

    private IEnumerator DamageAnimation()
    {
        _isTakeDamage = true;
        yield return new WaitForSeconds(.2f);
        _isTakeDamage = false;
    }
}
