using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Attack
{
	public Camera camera;
	public float damage;
	public bool isAttacking = false;

	public Vector2 attackDir;
	public Transform objectTransform;
	
	public void Attacking()
	{
		if (Input.GetButton("Fire1"))
		{
			isAttacking = true;
			MeleeAttack();
			return;
		}
		isAttacking=false;
		attackDir = Vector2.zero;
	}

	private void MeleeAttack()
	{
		Vector2 point = camera.ScreenToWorldPoint(Input.mousePosition);
		attackDir = FindDir(point, objectTransform.position);
	}


	private Vector2 FindDir(Vector2 point, Vector2 objectPos)
    {
		var x = Simplify(point - objectPos);
		return x;
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
