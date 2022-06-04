using UnityEngine;


public class PlayerMovement
{
    public Rigidbody2D rigidbody;
    public Animator animator;
    public float speed;
    public float runSpeed;
    public float stamina;

    public bool isRuning;
    public bool isRestingStamina;
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
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0 & !isRestingStamina)
            {
                isRuning = true;
                stamina -= 2;
                return runSpeed;
            }
            if (stamina <= 0 & !isRestingStamina)
                isRestingStamina = true;
            if (stamina >= 20 && isRestingStamina)
                isRestingStamina = false;
            stamina += 1;
            return speed; 
        }
    }
    public void Move(Vector2 input)
    {
        rigidbody.MovePosition(rigidbody.position + input * _speed * Time.deltaTime);
    }

}
