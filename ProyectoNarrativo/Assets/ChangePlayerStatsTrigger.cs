using TMPro;
using UnityEngine;

public class ChangePlayerStatsTrigger : MonoBehaviour
{

    public PlayerMovement player;
    bool isFirstEntry;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFirstEntry = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
                player.maxStats = 11;
                

            }
            
        }
    }
}
