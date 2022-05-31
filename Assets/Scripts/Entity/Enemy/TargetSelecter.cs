using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelecter : MonoBehaviour
{
    [SerializeField] private float _delayedForgetting = 10f;

    private GameObject _parent;
	private GameObject _target;

	private CircleCollider2D _circleCollider;
    private Enemy _enemy; 

    private bool _isCol = false;

	private void Start()
	{
		_parent = transform.parent.gameObject;
        _enemy = _parent.GetComponent<Enemy>();

        _circleCollider = GetComponent<CircleCollider2D>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
			_target = other.gameObject;
            _isCol = true;
            _enemy.target = _target.transform;
            _enemy.isTarget = true;
        }
    }

    private IEnumerator OnTriggerExit2D(Collider2D collision)
    {
        yield return new WaitForSeconds(_delayedForgetting);
        if (collision.CompareTag("Player") && _isCol)
        {
            _isCol=false;
            _target = null;
            _enemy.isTarget = false;
            _enemy.target = null;
        }
    }
    

}
