using UnityEngine;


public class PlayerMovement
{
    public Rigidbody2D rigidbody;
    public Animator animator;
    public float speed;
    public float runSpeed;
    public float stamina;

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
            isRuning = false;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRuning = true;
                return runSpeed;
            }
            return speed; 
        }
    }
    public void Move(Vector2 input)
    {
        rigidbody.MovePosition(rigidbody.position + input * _speed * Time.deltaTime);
    }

}
