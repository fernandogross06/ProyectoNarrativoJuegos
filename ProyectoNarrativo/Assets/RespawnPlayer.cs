using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject dialogo;
    private DialogueBehaviour dialogueBehaviour;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueBehaviour = dialogo.GetComponent<DialogueBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = spawnPoint.position;
            dialogueBehaviour.StartDialog();
        }    
    }


}
