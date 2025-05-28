using UnityEngine;

public class ChangeZoneCamera : MonoBehaviour
{
    public Transform targetPosition;
    public float targetSize = 5f;
    public DamageZone damageZone;
    public Transform respawnPoint;
    public bool isFirstEntry = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isFirstEntry)
            {
                isFirstEntry = false;

                // Acá llama al dialogo si lo tiene
                // if HAY DIALOGOS
                // ENCOLAR DIALOGOS


            }
            CameraManager.Instance.MoveTo(targetPosition.position, targetSize);
            if(respawnPoint != null) { 
            damageZone.respawnPoint = respawnPoint;
            }
        }
    }
}
