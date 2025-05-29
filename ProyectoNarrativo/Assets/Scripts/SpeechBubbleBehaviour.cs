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

       
        bool isCacique = speakerTransform.name.ToLower().Contains("cacique");
        

        AplicarTransformaciones(isCacique);
    }

    void AplicarTransformaciones(bool invertY = false)
    {
        if (currentSpeaker == null) return;

        Debug.DrawLine(currentSpeaker.position, transform.position, Color.red, 1f);

        int invertir = 1;
        bool isCacique = currentSpeaker.name.ToLower().Contains("cacique");
        
        if (isCacique)
        {
         
            invertir = -1;
        }

        Vector3 nuevaEscala = new Vector3(
            Mathf.Abs(currentSpeaker.localScale.x) * scaleOffset.x,
            currentSpeaker.localScale.y * scaleOffset.y * invertir,
            currentSpeaker.localScale.z * scaleOffset.z
        );
        transform.localScale = nuevaEscala;

 

        
        foreach (Transform child in transform)
        {
            Vector3 childScale = child.localScale;
            childScale.y = Mathf.Abs(childScale.y) * invertir;
            child.localScale = childScale;
        }

        Vector3 offsetUsado = localOffset;
        offsetUsado.y *= invertir;

        Vector3 nuevaPosicion = currentSpeaker.position + offsetUsado;
        nuevaPosicion.z = -1f;
        transform.position = nuevaPosicion;
    }
}
