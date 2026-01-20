using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public AudioSource audioSource;
    private XRBaseInteractable interactable;
    public float rotationAngle = 1f;
    public bool isRotating = false;
    private void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
    }

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(OnSelect);
    }

    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnSelect);
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        if (!isRotating)
        {
            if (args.interactorObject.transform.name.Contains("Right"))
                rotationAngle = 1f;
            else
                rotationAngle = -1f;
            StartCoroutine(RotateCoroutine());
        }
    }
    private IEnumerator RotateCoroutine()
    {
        isRotating = true;

        if (audioSource != null)
            audioSource.Play();

        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(rotationAngle, 0f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        if (audioSource != null && audioSource.isPlaying)
            audioSource.Stop();

        isRotating = false;
    }
}

