using UnityEngine;

public class SimpleMouseMove : MonoBehaviour
{
    public float moveSpeed = 2f;

    void Update()
    {
        if (Input.GetMouseButton(0)) // clic gauche
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetMouseButton(1)) // clic droit
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
