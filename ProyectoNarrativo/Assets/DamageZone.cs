using UnityEngine;

public class DamageZone : MonoBehaviour
{

    public RespawnPlayer respawnPlayer;
    public Transform respawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Debug.Log("Toqué al jugador");
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            respawnPlayer.spawnPoint = respawnPoint;
            respawnPlayer.PlayerDeath();

        }
    }
}
