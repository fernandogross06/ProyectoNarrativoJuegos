using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;



public class tutorialDialogue : MonoBehaviour
{
   
  
   
  
    public bool isFirstEntry = true;

    [Header("Diálogos de esta zona")]
    public List<DialogueLine> dialogueLines;

    [Header("Control de movimiento")]
    public bool detenerMovimiento = true;

    private DialogueBehaviour dialogueBehaviour;
    public GameObject dialogo;

    public Vector3 posicionActual;


    public GameObject tutorial1;
    public GameObject tutorial2;
    private void Start()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        dialogueBehaviour = dialogo.GetComponent<DialogueBehaviour>();
        //dialogueBehaviour.SetCaciquePosition(posicionActual);
    }

    public void TutorialSequence()
    {


        dialogueBehaviour.SetCaciquePosition(posicionActual);

        if (detenerMovimiento)
        {
            dialogueBehaviour.stopMovement();
        }

        StartCoroutine(TutorialWait());

    }

    public void MostrarTextoTutorial()
    {
        tutorial1.SetActive(true);
        tutorial2.SetActive(true);
    }

    IEnumerator TutorialWait()
    {
        //print(Time.time);
        //animator.SetBool("IsDeath", true);
        //animator.SetBool("IsJumping", false);
        //animator.SetBool("IsSliding", false);
        //movement.enabled = false;
        //rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(4);

        EnqueueDialogueLines();

        //animator.SetBool("IsDeath", false);
        //isDeath = false;
        //movement.enabled = true;
        //rb.bodyType = RigidbodyType2D.Dynamic;
        //respawn.PlayerDeath();
    }


    private void EnqueueDialogueLines()
    {
        foreach (var line in dialogueLines)
        {
            switch (line.speaker)
            {
                case DialogueLine.Speaker.Player:
                    dialogueBehaviour.setDialoguePlayer(
                        line.text,
                        line.disableAfterLine,
                        line.enableBeforeLine 
                    );
                    break;

                case DialogueLine.Speaker.Cacique:
                    dialogueBehaviour.setDialogueCacique(
                        line.text,
                        line.disableAfterLine,
                        line.enableBeforeLine 
                    );
                    break;
            }
        }
    }

}







