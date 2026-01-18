using UnityEngine;

public class KeyboardMove : MonoBehaviour
{
    public float speed = 3f;
    public float scrollSpeed = 8f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // A/D
        float z = Input.GetAxis("Vertical");   // W/S

        Vector3 move = (transform.right * x + transform.forward * z) * speed * Time.deltaTime;
        transform.position += move;

        // Molette: avancer / reculer
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.forward * (scroll * scrollSpeed);
    }
}
