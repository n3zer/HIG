using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelecter : MonoBehaviour
{
    [SerializeField] private float _delayedForgetting = 10f;

    private GameObject _parent;
	private GameObject _target;

	private CircleCollider2D _circleCollider;

	private void Start()
	{
		_parent = transform.parent.gameObject;
		_circleCollider = GetComponent<CircleCollider2D>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
			_target = other.gameObject;
        }
    }

    private IEnumerator OnTriggerExit2D(Collider2D collision)
    {
        yield return new WaitForSeconds(_delayedForgetting);
        if (_target.CompareTag("Player")) _target = null;
    }
}
