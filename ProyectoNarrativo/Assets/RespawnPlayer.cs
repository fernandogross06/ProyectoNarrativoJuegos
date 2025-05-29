using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject dialogo;
    private DialogueBehaviour dialogueBehaviour;
    public PlayerMovement player;
    int respawnTimesScene1 = 0;
    public bool scene1 = true;
    public bool scene2 = false;
    public bool scene3 = false;
    private List<string> frasesAleatorias = new List<string>
    {
    "No te rindas.",
    "Puedes llegar hasta all�.",
    "Intenta saltar en el �ltimo segundo.",
    "Puedes hacerlo."
    };

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
            //dialogueBehaviour.StartNextDialogue(); //  iniciar el siguiente di�logo
        }
    }


    public void PlayerDeath()
    {
        // Animation Pop()
        // Sound
        transform.position = spawnPoint.position;
        player.NextPlayerStats();
        respawnTimesScene1++;

        if (scene1)
        {
            if (respawnTimesScene1 == 1)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialoguePlayer("�Qu� acaba de pasar?");
                dialogueBehaviour.setDialogueCacique("Una de las particularidades de este mundo.");
                dialogueBehaviour.setDialogueCacique("Ahora, intenta llegar a la isla por tu cuenta.");
            }

            if (respawnTimesScene1 == 2)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialogueCacique("�Ahora lo entiendes?");
                dialogueBehaviour.setDialoguePlayer("�S�! �Es incre�ble! �A diferencia del mundo real,");
                dialogueBehaviour.setDialoguePlayer("en este mundo aunque me equivoque puedo intentarlo de nuevo!");
                dialogueBehaviour.setDialogueCacique("No exactamente, en el �mundo real� tamb-");
                dialogueBehaviour.setDialogueCacique("*suspira*");
                dialogueBehaviour.setDialogueCacique("As� es. En este mundo la voluntad es el �nico l�mite.");
                dialogueBehaviour.setDialogueCacique("Puedes volver a intentar los desaf�os a los que te enfrentes cuantas veces quieras.");
                dialogueBehaviour.setDialoguePlayer("�Incre�ble!");
            }

            if (respawnTimesScene1 == 3)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialoguePlayer("�Disculpe� este� �Se�or? Creo que definitivamente no puedo llegar al otro lado.");
                dialogueBehaviour.setDialogueCacique("No te rindas.");
            }

            if (respawnTimesScene1 == 4)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialoguePlayer("�");
                dialogueBehaviour.setDialogueCacique("Believe in yourself.");
            }

            if (respawnTimesScene1 == 5)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialoguePlayer("�");
                dialogueBehaviour.setDialogueCacique("Never give up. Never say never.");
                dialogueBehaviour.setDialoguePlayer("�");
            }

            if (respawnTimesScene1 == 6)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialoguePlayer("�Ser� que�?");
                dialogueBehaviour.setDialogueCacique("Sigue intent�ndolo.");

            }
     
            if(respawnTimesScene1>6 )
            {
                dialogueBehaviour.stopMovement();
                string frase = frasesAleatorias[Random.Range(0, frasesAleatorias.Count)];
                dialogueBehaviour.setDialogueCacique(frase);
            }
        }

       


    }
}
