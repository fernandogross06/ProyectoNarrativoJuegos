using UnityEngine;

[ExecuteAlways]
public class SpeechBubbleBehaviour : MonoBehaviour
{
    [Header("Posición relativa al padre")]
    public Vector3 localOffset = new Vector3(3f, 2.5f, 0f);

    [Header("Escala personalizada (se multiplica por la escala del padre)")]
    public Vector3 scaleOffset = new Vector3(-0.6f, 0.6f, 1f);

    private Transform character_transform;
    public GameObject character;

    void Start()
    {
        character_transform = character.transform;

        if (character_transform != null)
        {
            AplicarTransformaciones();
        }
    }

    void Update()
    {
        // Siempre chequea el padre en Update en caso de que algo cambie en el editor
        character_transform = character.transform;

        if (character_transform != null)
        {
            AplicarTransformaciones();
        }
    }

    void AplicarTransformaciones()
    {
        // Escala personalizada basada en la del padre
        Vector3 nuevaEscala = new Vector3(
            Mathf.Abs(character_transform.localScale.x) * scaleOffset.x,
            character_transform.localScale.y * scaleOffset.y,
            character_transform.localScale.z * scaleOffset.z
        );
        transform.localScale = nuevaEscala;

        // Posición global con Z fijo en -1
        Vector3 nuevaPosicion = character_transform.position + localOffset;
        nuevaPosicion.z = -1f;
        transform.position = nuevaPosicion;
        
    }
}
