using UnityEngine;

public class OpenDoorSmooth : MonoBehaviour
{
    public float openAngle = 90f; // L'angle d'ouverture
    public float speed = 120f; // La vitesse de la rotation

    private bool isOpen = false; // Si la porte est ouverte ou fermée
    private bool isMoving = false; // Si la porte est en mouvement
    private Quaternion closedRot; // La rotation de la porte quand elle est fermée
    private Quaternion openRot; // La rotation de la porte quand elle est ouverte

    void Start()
    {
        closedRot = transform.localRotation;
        openRot = Quaternion.Euler(0f, openAngle, 0f) * closedRot; // Rotation désirée
    }

    void Update()
    {
        if (!isMoving) return;

        Quaternion targetRotation = isOpen ? closedRot : openRot;
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, speed * Time.deltaTime);

        // Arrêter la rotation quand la porte atteint la position cible
        if (Quaternion.Angle(transform.localRotation, targetRotation) < 0.1f)
        {
            transform.localRotation = targetRotation;
            isMoving = false;
        }
    }

    // Appelée pour interagir et ouvrir/fermer la porte
    public void Interact()
    {
        if (isMoving) return; // Si la porte est déjà en mouvement, on ne fait rien

        isOpen = !isOpen;
        isMoving = true;
    }
}
