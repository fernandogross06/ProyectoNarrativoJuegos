using UnityEngine;

[ExecuteAlways]
public class SpeechBubbleBehaviour : MonoBehaviour
{
    [Header("Posición relativa al padre")]
    public Vector3 localOffset = new Vector3(3f, 2.5f, 0f);

    [Header("Escala personalizada (se multiplica por la escala del padre)")]
    public Vector3 scaleOffset = new Vector3(-0.6f, 0.6f, 1f);

    private Transform padre;

    void Start()
    {
        padre = transform.parent;

        if (padre != null)
        {
            AplicarTransformaciones();
        }
    }

    void Update()
    {
        // Siempre chequea el padre en Update en caso de que algo cambie en el editor
        padre = transform.parent;

        if (padre != null)
        {
            AplicarTransformaciones();
        }
    }

    void AplicarTransformaciones()
    {
        // Escala personalizada basada en la del padre
        Vector3 nuevaEscala = new Vector3(
            padre.localScale.x * scaleOffset.x,
            padre.localScale.y * scaleOffset.y,
            padre.localScale.z * scaleOffset.z
        );
        transform.localScale = nuevaEscala;

        // Posición global con Z fijo en -1
        Vector3 nuevaPosicion = padre.position + localOffset;
        nuevaPosicion.z = -1f;
        transform.position = nuevaPosicion;
    }
}
