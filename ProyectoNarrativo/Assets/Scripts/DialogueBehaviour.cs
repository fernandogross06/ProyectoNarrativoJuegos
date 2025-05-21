using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public class DialogueSet
{
    public List<string> dialogueLines;
    public List<GameObject> characters;
}
public class DialogueBehaviour : MonoBehaviour
{
    [SerializeField] int letterPerSeconds;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] List<DialogueSet> allDialogues;

    public SpeechBubbleBehaviour speechBubble;
    public GameObject dialogGameObject;

    private DialogueSet currentDialogue;
    private int currentDialogueIndex = -1;
    private int currentLineIndex = 0;
    private int currentSpeakerIndex = 0;

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
                dialogueText.text = currentDialogue.dialogueLines[currentLineIndex];
                isTyping = false;
            }
            else
            {
                currentLineIndex++;
                currentSpeakerIndex = currentLineIndex % currentDialogue.characters.Count;

                if (currentLineIndex < currentDialogue.dialogueLines.Count)
                {
                    typingCoroutine = StartCoroutine(TypeDialog(currentDialogue.dialogueLines[currentLineIndex]));
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

        if (currentDialogue.dialogueLines.Count == 0 || currentDialogue.characters.Count == 0)
        {
            Debug.LogWarning("El diálogo actual no tiene líneas o personajes.");
            return;
        }

        currentLineIndex = 0;
        currentSpeakerIndex = 0;

        dialogGameObject.SetActive(true);
        typingCoroutine = StartCoroutine(TypeDialog(currentDialogue.dialogueLines[currentLineIndex]));
    }

    private IEnumerator TypeDialog(string dialog)
    {
        isTyping = true;
        dialogueText.text = "";

        GameObject currentSpeaker = currentDialogue.characters[currentSpeakerIndex];
        Transform speakerTransform = currentSpeaker.transform;

        if (speechBubble != null)
        {
            speechBubble.SetCurrentSpeaker(speakerTransform);
        }

        foreach (char letter in dialog.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSeconds);
        }

        isTyping = false;
    }
}
