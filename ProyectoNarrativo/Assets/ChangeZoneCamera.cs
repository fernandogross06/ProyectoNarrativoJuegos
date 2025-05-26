using UnityEngine;

public class ChangeZoneCamera : MonoBehaviour
{
    public Transform targetPosition;
    public float targetSize = 5f;
    public DamageZone damageZone;
    public Transform respawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraManager.Instance.MoveTo(targetPosition.position, targetSize);
            if(respawnPoint != null) { 
            damageZone.respawnPoint = respawnPoint;
            }
        }
    }
}
