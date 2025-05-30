using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject dialogo;
    private DialogueBehaviour dialogueBehaviour;
    public PlayerMovement player;
    int respawnTimesScene1 = 0;
    int respawnTimesScene2 = 0;
    int respawnTimesScene4 = 0;
    
    public bool scene1 = true;
    public bool scene2 = false;
    public bool scene3 = false;
    public bool scene4 = false;
    public bool scene5 = false;


    public AudioSource audioSource;
    public AudioClip respawnClip;
    public int maxLevel;
    private List<string> frasesAleatorias = new List<string>
    {
    "No te rindas.",
    "Puedes llegar hasta all�.",
    "Intenta saltar en el �ltimo segundo.",
    "Puedes hacerlo."
    };


    private List<string> frasesAleatorias2 = new List<string>
    {
    "Estoy seguro de que puedes hacerlo.",
    "No te rindas.",
    "S� se puede.",
    "Recuerda, contin�a avanzando y salta cuando toques la pared"
    };

    private List<string> frasesAleatorias3 = new List<string>
    {
    "Siento que salto m�s bajo cada vez�",
    "No�",
    "No puedo�",
    "�Habr� una manera m�s f�cil? No� si aparezco aqu� es por algo�",
    "�"
    };

    private List<string> frasesAleatorias4 = new List<string>
    {
    "Vamos de nuevo.",
    "Paciencia� paciencia�",
    "Vamos otra vez.",
    "Esta es la buena",
    "Uno, dos. Uno, dos."
    };
    void Start()
    {
        dialogueBehaviour = dialogo.GetComponent<DialogueBehaviour>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        /*
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
        */
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
        audioSource.PlayOneShot(respawnClip, 1);
        player.NextPlayerStats();
        

        if (scene1)
        {
            respawnTimesScene1++;
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
                
                string frase = frasesAleatorias[Random.Range(0, frasesAleatorias.Count)];
                dialogueBehaviour.setDialogueCacique(frase);
            }
        }

        if (scene2)
        {

            respawnTimesScene2++;
            if (respawnTimesScene2 == 1)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialogueCacique("S� que puedes hacerlo. No dejes de avanzar.");
                dialogueBehaviour.setDialoguePlayer("Voy a intentarlo."); 
               
            }
            if (respawnTimesScene2 == 2)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialogueCacique("Sigue intent�ndolo");
                dialogueBehaviour.setDialoguePlayer("Est� bien.");

            }
            if (respawnTimesScene2 == 3)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialoguePlayer("�");
                dialogueBehaviour.setDialogueCacique("Abraza la pared mientras saltas repetidamente.");
                dialogueBehaviour.setDialoguePlayer("Voy a intentarlo.");

            }
            if (respawnTimesScene2 == 4)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialogueCacique("No te rindas. ");
                dialogueBehaviour.setDialoguePlayer("�No!");

            }
            if (respawnTimesScene2 == 5)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialogueCacique("SEstoy seguro de que lo puedes hacer. Recuerda no dejar de avanzar mientras saltas.");
                dialogueBehaviour.setDialoguePlayer("�S�!");

            }
            if (respawnTimesScene2 > 5)
            {

                string frase = frasesAleatorias2[Random.Range(0, frasesAleatorias.Count)];
                dialogueBehaviour.setDialogueCacique(frase);
            }

        }

        if (scene4)
        {
            respawnTimesScene4++;

            if (respawnTimesScene4 == 1)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialoguePlayer("Ouch.");

            }

            if (respawnTimesScene4 == 2)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialoguePlayer("�Es posible saltarse eso?");

            }

            if (respawnTimesScene4 == 3)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialoguePlayer("No s� si pueda�");

            }

            if (respawnTimesScene4 == 4)
            {
                dialogueBehaviour.stopMovement();
                dialogueBehaviour.setDialoguePlayer("�");

            }

            if (respawnTimesScene4 > 4)
            {
                dialogueBehaviour.stopMovement();
                string frase = frasesAleatorias3[Random.Range(0, frasesAleatorias.Count)];
                dialogueBehaviour.setDialoguePlayer(frase);
                
            }

        }

        if (scene5)
        {
            
                dialogueBehaviour.stopMovement();
                string frase = frasesAleatorias4[Random.Range(0, frasesAleatorias.Count)];
                dialogueBehaviour.setDialoguePlayer(frase);

            
        }
    }
}
