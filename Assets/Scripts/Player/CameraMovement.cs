using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 200f)] private float _speed = 10f;
    
    private Vector2 _moveDirection
    {
        get 
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            return new Vector2(x, y); 
        }
    }

    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        if (Input.GetMouseButton(2))
            transform.Translate(-_moveDirection * _speed * Time.deltaTime);
    }
}
