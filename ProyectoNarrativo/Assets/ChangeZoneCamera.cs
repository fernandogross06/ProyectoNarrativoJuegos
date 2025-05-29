using UnityEngine;

public class ChangeZoneCamera : MonoBehaviour
{
    public Transform targetPosition;
    public float targetSize = 5f;
    public DamageZone damageZone;
    public Transform respawnPoint;
    public bool isFirstEntry = true;
    private RespawnPlayer zones;

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
                if(collision.gameObject.name == "ZoneChangeSecondLevel")
                {
                    zones.scene1 = false;
                    zones.scene2 = true;
                }

            }
            CameraManager.Instance.MoveTo(targetPosition.position, targetSize);
            if(respawnPoint != null) { 
            damageZone.respawnPoint = respawnPoint;
            }
        }
    }
}
