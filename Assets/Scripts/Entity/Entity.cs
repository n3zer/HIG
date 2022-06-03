using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	[SerializeField] private float _health;
	[SerializeField] private float _armor;
	[SerializeField] private bool _canTakeDamage;

	private bool _isTakeDamage;

	public Animator _animator;

	public void SetAnimation(Vector2 dir)
	{
		_animator.SetFloat("horizontal", dir.x);
		_animator.SetFloat("vertical", dir.y);
		_animator.SetBool("isTakeDamage", _isTakeDamage);
	}

	public void TakeDamage(float damage)
	{

		if (_canTakeDamage)
		{
			StartCoroutine(DamageAnimation());
			_health -= damage / (0.55f * _armor);
			if (_health <= 0)
				Destroy(gameObject);
		}
	}

	private IEnumerator DamageAnimation()
	{
		_isTakeDamage = true;
		yield return new WaitForSeconds(.2f);
		_isTakeDamage = false;
	}
}
