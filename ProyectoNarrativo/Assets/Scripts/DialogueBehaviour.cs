﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;


[System.Serializable]

public class DialogueEntry
{
    public GameObject character;
    [TextArea]
    public string line;
    public bool disableAfterLine;
    public bool enableBeforeLine;
}

[System.Serializable]
public class DialogueSet
{
    public List<DialogueEntry> dialogueEntries;
}


public class DialogueBehaviour : MonoBehaviour
{
    [SerializeField] int letterPerSeconds = 30;
    [SerializeField] TextMeshProUGUI dialogueText;
    
    [SerializeField] GameObject player;
    [SerializeField] GameObject cacique;
    private Queue<DialogueEntry> dialogueQueue = new Queue<DialogueEntry>();
    [SerializeField] float delayBetweenDialogues = 0.5f;

     private Rigidbody2D playerRb;

    public SpeechBubbleBehaviour speechBubble;
    public GameObject dialogGameObject;
    private Animator playerAnimator;



    private Coroutine typingCoroutine;
    private bool isTyping = false;

    public PlayerMovement movement;

    void Start()
    {
        dialogGameObject.SetActive(false);
        playerRb = player.GetComponent<Rigidbody2D>();
        playerAnimator = player.GetComponent<Animator>();
    }

    private void Update()
    {
        //descomentar si se quiere que se pasen los dialogos con espacio o alguna tecla
        /*
        if (Input.GetKeyDown(KeyCode.Space) && dialogGameObject.activeSelf)
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = currentDialogue.dialogueEntries[currentLineIndex].line;
                isTyping = false;
            }
            else
            {
                currentLineIndex++;

                if (currentLineIndex < currentDialogue.dialogueEntries.Count)
                {
                    var entry = currentDialogue.dialogueEntries[currentLineIndex];
                    typingCoroutine = StartCoroutine(TypeDialog(entry.line, entry.character));
                }
                else
                {
                    dialogGameObject.SetActive(false);
                }
            }
        }*/
    }

    /*public void StartNextDialogue()
    {
        if (allDialogues.Count == 0) return;

        currentDialogueIndex = (currentDialogueIndex + 1) % allDialogues.Count;
        currentDialogue = allDialogues[currentDialogueIndex];

        if (currentDialogue.dialogueEntries.Count == 0)
        {
            Debug.LogWarning("El dialogo actual no tiene entradas.");
            return;
        }

        currentLineIndex = 0;

        dialogGameObject.SetActive(true);
        var entry = currentDialogue.dialogueEntries[0];
        typingCoroutine = StartCoroutine(TypeDialog(entry.line, entry.character));
    }*/

    private IEnumerator TypeDialog(DialogueEntry entry)
    {
        isTyping = true;
        dialogueText.text = "";

        GameObject character = entry.character;

        // 🔹 Activar antes de hablar si se indica
        if (entry.enableBeforeLine && character != null && !character.activeSelf)
        {
            character.SetActive(true);
        }

        if (speechBubble != null && character != null)
        {
            speechBubble.SetCurrentSpeaker(character.transform);
        }

        foreach (char letter in entry.line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSeconds);
        }

        isTyping = false;

        // 🔹 Desactivar después de hablar si se indica
        if (entry.disableAfterLine && character != null)
        {
            character.SetActive(false);
        }

        if (dialogueQueue.Count > 0)
        {
            yield return new WaitForSeconds(delayBetweenDialogues);

            DialogueEntry next = dialogueQueue.Dequeue();
            typingCoroutine = StartCoroutine(TypeDialog(next));
        }
        else
        {
            yield return new WaitForSeconds(delayBetweenDialogues);
            dialogGameObject.SetActive(false);
            if (movement != null)
            {
                movement.enabled = true;
            }
        }
    }



    public void setDialoguePlayer(string line, bool disableAfterLine = false, bool enableBeforeLine = false)
    {
        DialogueEntry entry = new DialogueEntry
        {
            character = player,
            line = line,
            disableAfterLine = disableAfterLine,
            enableBeforeLine = enableBeforeLine
        };

        if (isTyping)
        {
            dialogueQueue.Enqueue(entry);
        }
        else
        {
            dialogGameObject.SetActive(true);
            typingCoroutine = StartCoroutine(TypeDialog(entry));
        }
    }

    public void setDialogueCacique(string line, bool disableAfterLine = false, bool enableBeforeLine = false)
    {
        DialogueEntry entry = new DialogueEntry
        {
            character = cacique,
            line = line,
            disableAfterLine = disableAfterLine,
            enableBeforeLine = enableBeforeLine
        };

        if (isTyping)
        {
            dialogueQueue.Enqueue(entry);
        }
        else
        {
            dialogGameObject.SetActive(true);
            typingCoroutine = StartCoroutine(TypeDialog(entry));
        }
    }



    public void stopMovement()
    {
        movement.enabled = false;

        if (playerRb != null)
        {
            playerRb.linearVelocity = Vector2.zero;
        }

        if(playerAnimator != null){
            // Supongamos que usás un parámetro float "Speed"
            playerAnimator.SetFloat("Speed", 0f);
         
            // O si tenés un trigger "Idle"
            // playerAnimator.SetTrigger("Idle");
        }
    }

    public void SetCaciquePosition(Vector3 nuevaPosicion)
    {
        
            cacique.transform.position = nuevaPosicion;

           
        
    }


}
