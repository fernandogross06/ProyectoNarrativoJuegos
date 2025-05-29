using System;
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
        if(zones == null)
        {
            zones = collision.GetComponent<RespawnPlayer>();
        }
      
        if (collision.CompareTag("Player"))
        {
            if (isFirstEntry)
            {
                isFirstEntry = false;

                // Acá llama al dialogo si lo tiene
                // if HAY DIALOGOS
                // ENCOLAR DIALOGOS
              
                if(gameObject.CompareTag("ZONA2"))
                {
                    zones.scene1 = false;
                    zones.scene2 = true;
                }

                if (gameObject.CompareTag("ZONA3"))
                {
                    zones.scene2 = false;
                    zones.scene3 = true;
                }

                if (gameObject.CompareTag("ZONA4"))
                {
                    zones.scene3 = false;
                    zones.scene4 = true;
                }
                if (gameObject.CompareTag("ZONA5"))
                {
                    zones.scene4 = false;
                    zones.scene5 = true;
                }

            }
            CameraManager.Instance.MoveTo(targetPosition.position, targetSize);
            if(respawnPoint != null) { 
            damageZone.respawnPoint = respawnPoint;
            }
        }
    }
}
