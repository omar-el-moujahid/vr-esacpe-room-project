using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenDoorVR : MonoBehaviour
{
    public Transform pivot;          // DoorPivot
    public float minAngle = 0f;       // porte fermée
    public float maxAngle = 90f;      // porte ouverte

    private XRGrabInteractable grab;
    private Transform interactor;
    private float startAngle;
    private Vector3 startDirection;

    private void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        grab.selectEntered.AddListener(OnGrab);
        grab.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        grab.selectEntered.RemoveListener(OnGrab);
        grab.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        interactor = args.interactorObject.transform;

        Vector3 doorToHand = interactor.position - pivot.position;
        startDirection = Vector3.ProjectOnPlane(doorToHand, Vector3.up).normalized;

        startAngle = pivot.localEulerAngles.y;
        if (startAngle > 180f)
            startAngle -= 360f;
    }

    private void Update()
    {
        if (interactor == null)
            return;

        Vector3 doorToHand = interactor.position - pivot.position;
        Vector3 currentDirection = Vector3.ProjectOnPlane(doorToHand, Vector3.up).normalized;

        float angleDelta = Vector3.SignedAngle(startDirection, currentDirection, Vector3.up);
        float targetAngle = Mathf.Clamp(startAngle + angleDelta, minAngle, maxAngle);

        pivot.localRotation = Quaternion.Euler(0f, targetAngle, 0f);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        interactor = null;
    }
}
