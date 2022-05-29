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

	private Animator animator;
	private AnimationClip AttackedAnimationClip;
	private Entity _target;

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
		
		RaycastHit2D[] hits;
		hits = Physics2D.RaycastAll(objectTransform.position, attackDir, attackRange);
        if (hits.Length > 1)
        {
			hits[1].transform.TryGetComponent<Entity>(out _target);
		}
		

        if (_target != null)
        {
			_target.TakeDamage(damage);
			_target = null;
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
		}
		else
		{
			point.y = point.y / Math.Abs(point.y);
			point.x = 0;
		}

		return point;
	}
}
