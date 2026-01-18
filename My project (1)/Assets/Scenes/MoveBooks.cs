using UnityEngine;

public class MoveBooks : MonoBehaviour
{
    public Vector3 slideOffset = new Vector3(0.15f, 0f, 0f);
    public float speed = 3f;

    private Vector3 closedPos;
    private Vector3 openPos;
    private bool isHolding = false;

    void Start()
    {
        closedPos = transform.localPosition;
        openPos = closedPos + slideOffset;
    }

    void Update()
    {
        Vector3 target = isHolding ? openPos : closedPos;

        transform.localPosition = Vector3.MoveTowards(
            transform.localPosition,
            target,
            speed * Time.deltaTime
        );
    }

    void OnMouseDown()
    {
        isHolding = true;
    }

    void OnMouseUp()
    {
        isHolding = false;
    }
}