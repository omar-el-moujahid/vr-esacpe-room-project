//using UnityEngine;

//public class MouseLook : MonoBehaviour
//{
//    public float sensitivity = 2f;
//    float xRotation = 0f;

//    void Start()
//    {
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;
//    }

//    void Update()
//    {
//        float mouseX = Input.GetAxis("Mouse X") * sensitivity * 100f * Time.deltaTime;
//        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * 100f * Time.deltaTime;

//        xRotation -= mouseY;
//        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

//        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
//        transform.parent.Rotate(Vector3.up * mouseX);
//    }
//}


using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float rotationSpeed = 200f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * rotationSpeed * Time.deltaTime, 0f);
    }
}
