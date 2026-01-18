using UnityEngine;

public class TestClick : Clickable
{
    public override void Interact()
    {
        Debug.Log("Je suis cliqué: " + gameObject.name);
    }
}
