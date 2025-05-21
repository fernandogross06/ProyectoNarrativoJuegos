using UnityEngine;

[ExecuteAlways]
public class SpeechBubbleBehaviour : MonoBehaviour
{
    [Header("Posición relativa al personaje")]
    public Vector3 localOffset = new Vector3(3f, 2.5f, 0f);

    [Header("Escala personalizada (se multiplica por la escala del personaje)")]
    public Vector3 scaleOffset = new Vector3(-0.6f, 0.6f, 1f);

    private Transform currentSpeaker;

    void Update()
    {
        if (currentSpeaker != null)
        {
            AplicarTransformaciones();
        }
    }

    public void SetCurrentSpeaker(Transform speakerTransform)
    {
        currentSpeaker = speakerTransform;
        AplicarTransformaciones();
    }

    void AplicarTransformaciones()
    {
        if (currentSpeaker == null) return;

        Vector3 nuevaEscala = new Vector3(
            Mathf.Abs(currentSpeaker.localScale.x) * scaleOffset.x,
            currentSpeaker.localScale.y * scaleOffset.y,
            currentSpeaker.localScale.z * scaleOffset.z
        );
        transform.localScale = nuevaEscala;

        Vector3 nuevaPosicion = currentSpeaker.position + localOffset;
        nuevaPosicion.z = -1f;
        transform.position = nuevaPosicion;
    }
}
