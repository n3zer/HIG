using UnityEngine;

public class CameraMovement
{
    public float cameraSpeed;
    public Camera camera;
    private Vector2 _moveDirection
    {
        get 
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            return new Vector2(x, y); 
        }
    }

    public void MoveCamera()
    {
        if (Input.GetMouseButton(2))
            camera.transform.Translate(-_moveDirection * cameraSpeed * Time.deltaTime);
    }
}
