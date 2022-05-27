using UnityEngine;


public class PlayerMovement
{
    public Rigidbody2D rigidbody;
    public Animator animator;
    public float speed;
    public float runSpeed;

    public bool isRuning;
    public Vector2 MoveDirection
    {
        get
        {
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");
            return new Vector2(x, y);
        }
    }

    private float _speed
    {
        get 
        {
            if (Input.GetKey(KeyCode.LeftShift)) return runSpeed; isRuning = true;
            isRuning = false;
            return speed; 
        }
    }
    public void Move(Vector2 input)
    {
        rigidbody.MovePosition(rigidbody.position + input * _speed * Time.deltaTime);
    }

}
