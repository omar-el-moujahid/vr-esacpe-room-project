using UnityEngine;

public class TVInteraction : MonoBehaviour
{
    public float LiftHeight = 0.6f;  // Hauteur à laquelle la TV sera soulevée
    public float LiftSpeed = 4f;     // Vitesse de levée
    public float DropSpeed = 3f;    // Vitesse de la chute

    private bool isHolding = false;  // Vérifie si l'oreiller est tenu par le joueur
    private bool isDropping = false; // Vérifie si la TV doit tomber
    private Vector3 originalPosition; // Position d'origine de la TV

    void Start()
    {
        originalPosition = transform.position;  // Enregistre la position d'origine
    }

    void Update()
    {
        if (isHolding)  // Si le joueur maintient le clic
        {
            LiftTV();
        }

        if (isDropping)  // Si le joueur relâche le clic
        {
            DropTV();
        }
    }

    void OnMouseDown()
    {
        // Quand le joueur commence à tenir la TV
        isHolding = true;
        isDropping = false; // Empêche que la TV tombe immédiatement
    }

    void OnMouseUp()
    {
        // Quand le joueur relâche le clic
        isHolding = false;
        isDropping = true;
    }

    void LiftTV()
    {
        // Soulever la TV à la hauteur définie
        float step = LiftSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, originalPosition.y + LiftHeight, transform.position.z), step);
    }

    void DropTV()
    {
        // Faire tomber la TV à la position originale
        float step = DropSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, originalPosition, step);

        // Arrêter de tomber quand on revient à la position d'origine
        if (Mathf.Abs(transform.position.y - originalPosition.y) < 0.1f)
        {
            isDropping = false;  // TV est revenue à sa position d'origine
        }
    }
}
