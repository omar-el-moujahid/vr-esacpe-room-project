using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TiroirVR : MonoBehaviour
{
    [Header("Pivot du tiroir (au niveau du rail)")]
    public Transform pivot;

    [Header("Limites du tiroir")]
    public Vector3 minLocalPos;
    public Vector3 maxLocalPos;

    private XRGrabInteractable grab;
    private Transform hand;
    private Vector3 startHandPos;
    private Vector3 startLocalPos;

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
        hand = args.interactorObject.transform;
        startHandPos = hand.position;
        startLocalPos = pivot.localPosition;
    }

    private void Update()
    {
        if (hand == null) return;

        Vector3 handDelta = hand.position - startHandPos;
        Vector3 targetPos = startLocalPos + new Vector3(handDelta.x, 0f, handDelta.z); // dépend de ton axe de tiroir

        // Limiter la position
        targetPos.x = Mathf.Clamp(targetPos.x, minLocalPos.x, maxLocalPos.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minLocalPos.y, maxLocalPos.y);
        targetPos.z = Mathf.Clamp(targetPos.z, minLocalPos.z, maxLocalPos.z);

        pivot.localPosition = targetPos;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        hand = null;
    }
}
