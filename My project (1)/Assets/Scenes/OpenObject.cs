using UnityEngine;

public class OpenObjectSmooth : Clickable
{
    public Vector3 openLocalOffset;
    public float speed = 5f;

    Vector3 closedLocalPos;
    Vector3 openLocalPos;

    bool isOpen = false;
    bool isMoving = false;
    Vector3 targetPos;

    void Start()
    {
        closedLocalPos = transform.localPosition;
        openLocalPos = closedLocalPos + openLocalOffset;
    }

    void Update()
    {
        if (!isMoving) return;

        transform.localPosition = Vector3.MoveTowards(
            transform.localPosition,
            targetPos,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.localPosition, targetPos) < 0.001f)
        {
            transform.localPosition = targetPos;
            isMoving = false;
        }
    }

    public override void Interact()
    {
        if (isMoving) return;

        isOpen = !isOpen;
        targetPos = isOpen ? openLocalPos : closedLocalPos;
        isMoving = true;
    }
}
