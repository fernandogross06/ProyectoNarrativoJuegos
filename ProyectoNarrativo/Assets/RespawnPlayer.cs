using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject dialogo;
    private DialogueBehaviour dialogueBehaviour;

    void Start()
    {
        dialogueBehaviour = dialogo.GetComponent<DialogueBehaviour>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = spawnPoint.position;
            dialogueBehaviour.StartNextDialogue(); //  iniciar el siguiente diálogo
        }
    }
}
