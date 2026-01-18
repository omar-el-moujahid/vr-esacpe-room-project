using UnityEngine;

public class MouseRotateHold : MonoBehaviour
{
    public float rotationSpeed = 220f;

    void Update()
    {
        // Maintenir clic droit pour tourner (360°)
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(0f, mouseX * rotationSpeed * Time.deltaTime, 0f);
        }
    }
}
