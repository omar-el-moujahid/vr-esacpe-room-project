
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JeterOreiller : MonoBehaviour
{
    public float floatHeight = 1.5f;   // hauteur quand on tient

    private Rigidbody rb;
    private bool isHolding = false;
    private Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // état normal : gravité active
        rb.useGravity = true;
        rb.isKinematic = false;

        startPos = transform.position;
    }

    void Update()
    {
        if (isHolding)
        {
            // flotter AU-DESSUS de la position d'origine
            transform.position = new Vector3(
                startPos.x,
                startPos.y + floatHeight,
                startPos.z
            );
        }
    }

    void OnMouseDown()
    {
        // on tient l’oreiller
        isHolding = true;

        rb.useGravity = false;
        rb.velocity = Vector3.zero;
    }

    void OnMouseUp()
    {
        // on lâche l’oreiller
        isHolding = false;

        rb.useGravity = true;
    }
}

