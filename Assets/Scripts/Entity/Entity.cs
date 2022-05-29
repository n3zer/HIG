using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]private float _health;
    [SerializeField]private float _armor;

    public void TakeDamage(float damage)
    {
        _health -= damage / (0.55f * _armor);
        Debug.Log(_health);
        if (_health <= 0)
            Destroy(gameObject);
    }
}
