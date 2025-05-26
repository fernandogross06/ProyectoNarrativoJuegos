using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject dialogo;
    private DialogueBehaviour dialogueBehaviour;
    public PlayerMovement player;

    void Start()
    {
        dialogueBehaviour = dialogo.GetComponent<DialogueBehaviour>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = spawnPoint.position;

            dialogueBehaviour.stopMovement();
            dialogueBehaviour.setDialogueCacique("linea cacique 1");
            dialogueBehaviour.setDialogueCacique("linea cacique 2");
            dialogueBehaviour.setDialoguePlayer("respuesta personaje");
            dialogueBehaviour.setDialoguePlayer("Vamos equipo, salimos jugando");
            dialogueBehaviour.setDialoguePlayer("Ball up top");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = spawnPoint.position;
            //dialogueBehaviour.StartNextDialogue(); //  iniciar el siguiente diálogo
        }
    }


    public void PlayerDeath()
    {
        // Animation Pop()
        // Sound
        transform.position = spawnPoint.position;
        player.NextPlayerStats();


    }
}
