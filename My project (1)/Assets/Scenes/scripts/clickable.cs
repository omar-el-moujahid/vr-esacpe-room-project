using UnityEngine;

public class Clickable : MonoBehaviour
{
    void OnMouseDown()
    {
        Interact();
    }

    public virtual void Interact() { }
}