using System;
using System.Collections;
using UnityEngine;


public class Attack
{
	public float cooldown = .3f;

	public Camera camera;
	public float damage;
	public bool isAttacking = false;
	public float attackRange = .7f;
	public Coroutine StartCoroutine;

	public Vector2 attackDir;
	public Transform objectTransform;

	private float lastTime;


	public void Attacking()
	{
		if (Time.time >= lastTime + cooldown && isAttacking)
		{
			isAttacking = false;
			attackDir = Vector2.zero;
		}
		if (Input.GetButton("Fire1") && !isAttacking)
		{
			isAttacking = true;
			MeleeAttack();
			lastTime = Time.time;
		}
	}

	private void MeleeAttack()
	{
		Vector2 point = camera.ScreenToWorldPoint(Input.mousePosition);
		attackDir = FindDir(point, objectTransform.position);

        Collider2D[] hitsEnemies = Physics2D.OverlapCircleAll(objectTransform.position, attackRange);
		foreach (Collider2D hit in hitsEnemies)
        {
            if (hit.gameObject.CompareTag("Enemy"))
            {
				Enemy enemy;
				hit.TryGetComponent<Enemy>(out enemy);
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
