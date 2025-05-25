using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public class DialogueEntry
{
    public GameObject character;
    [TextArea]
    public string line;
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
    [SerializeField] List<DialogueSet> allDialogues;

    public SpeechBubbleBehaviour speechBubble;
    public GameObject dialogGameObject;

    private DialogueSet currentDialogue;
    private int currentDialogueIndex = -1;
    private int currentLineIndex = 0;

    private Coroutine typingCoroutine;
    private bool isTyping = false;

    void Start()
    {
        dialogGameObject.SetActive(false);
    }

    private void Update()
    {
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
        }
    }

    public void StartNextDialogue()
    {
        if (allDialogues.Count == 0) return;

        currentDialogueIndex = (currentDialogueIndex + 1) % allDialogues.Count;
        currentDialogue = allDialogues[currentDialogueIndex];

        if (currentDialogue.dialogueEntries.Count == 0)
        {
            Debug.LogWarning("El di�logo actual no tiene entradas.");
            return;
        }

        currentLineIndex = 0;

        dialogGameObject.SetActive(true);
        var entry = currentDialogue.dialogueEntries[0];
        typingCoroutine = StartCoroutine(TypeDialog(entry.line, entry.character));
    }

    private IEnumerator TypeDialog(string dialog, GameObject character)
    {
        isTyping = true;
        dialogueText.text = "";

        if (speechBubble != null && character != null)
        {
            speechBubble.SetCurrentSpeaker(character.transform);
        }

        foreach (char letter in dialog.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSeconds);
        }

        isTyping = false;
    }


}
