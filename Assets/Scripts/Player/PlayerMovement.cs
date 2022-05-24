using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)] private float _speed = 2f;
    [SerializeField] private Camera _camera;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    private Vector2 _moveDirection
    {
        get
        {
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");
            return new Vector2(x, y);
        }
    }

    private void Update()
    {
        PointMove();
    }
    private void FixedUpdate()
    {
        Move(_moveDirection);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void PointMove()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Vector2 point = _camera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = point;
        }
        
    }
    private void Move(Vector2 input)
    {
        SetAnimation(input);
        _rigidbody.MovePosition(_rigidbody.position + input * _speed * Time.deltaTime);
    }

    private void SetAnimation(Vector2 input)
    {
        _animator.SetFloat("Horizontal", input.x);
        _animator.SetFloat("Vertical", input.y);
        _animator.SetFloat("Speed", input.sqrMagnitude);
    }

}
