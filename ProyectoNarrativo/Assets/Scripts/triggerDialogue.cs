using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class DialogueLine
{
    public enum Speaker { Player, Cacique }

    public Speaker speaker;
    [TextArea(2, 10)]
    public string text;
}

public class triggerDialogue : MonoBehaviour
{
   
  
   
  
    public bool isFirstEntry = true;

    [Header("Diálogos de esta zona")]
    public List<DialogueLine> dialogueLines;

    [Header("Control de movimiento")]
    public bool detenerMovimiento = true;

    private DialogueBehaviour dialogueBehaviour;
    public GameObject dialogo;

    public Vector3 posicionActual;

    private void Start()
    {
       
        dialogueBehaviour = dialogo.GetComponent<DialogueBehaviour>();
        dialogueBehaviour.SetCaciquePosition(posicionActual);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isFirstEntry)
            {
                print("sirve");
                isFirstEntry = false;

                if (detenerMovimiento)
                {
                    dialogueBehaviour.stopMovement();
                }

                EnqueueDialogueLines();
            }

           
        }
    }

    private void EnqueueDialogueLines()
    {
        foreach (var line in dialogueLines)
        {
            switch (line.speaker)
            {
                case DialogueLine.Speaker.Player:
                    dialogueBehaviour.setDialoguePlayer(line.text);
                    break;
                case DialogueLine.Speaker.Cacique:
                    dialogueBehaviour.setDialogueCacique(line.text);
                    break;
            }
        }
    }
}





 

