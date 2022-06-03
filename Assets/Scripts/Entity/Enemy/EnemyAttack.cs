using System;
using UnityEngine;

public class EnemyAttack
{
	public float cooldown = .3f;

	public float damage;
	public bool isAttacking = false;
	public bool attacking = false;
	public float attackRange = .7f;

	public Transform objectTransform;

	private float lastTime;


	public void Attacking()
	{
		if (Time.time >= lastTime + cooldown && isAttacking)
		{
			isAttacking = false;
		}
		if (attacking && !isAttacking)
		{
			isAttacking = true;
			MeleeAttack();
			lastTime = Time.time;
		}
	}

	private void MeleeAttack()
	{
		Collider2D[] hitsEnemies = Physics2D.OverlapCircleAll(objectTransform.position, attackRange);
		foreach (Collider2D hit in hitsEnemies)
		{
			if (hit.gameObject.CompareTag("Player"))
			{
				Player enemy;
				hit.TryGetComponent<Player>(out enemy);
				if (enemy != null)
				{
					enemy.TakeDamage(damage);
				}
			}
		}
	}

	private Vector2 FindDir(Vector2 point, Vector2 objectPos)
	{
		return Simplify(point - objectPos);
	}

	private Vector2 Simplify(Vector2 point)
	{
		if (Math.Abs(point.x) > Math.Abs(point.y))
		{
			point.x = point.x / Math.Abs(point.x);
			point.y = 0;
			return point;
		}
		else if (Math.Abs(point.x) < Math.Abs(point.y))
		{
			point.y = point.y / Math.Abs(point.y);
			point.x = 0;
			return point;
		}

		return new Vector2(0, 0);
	}
}
