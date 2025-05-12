using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextBehaviour : MonoBehaviour
{
    [SerializeField] int letterPerSeconds;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] List<string> dialogueLines;
    public SceneController sceneController;

    private int currentLineIndex = 0;
    private Coroutine typingCoroutine;
    private bool isTyping = false;


    void Start()
    {
        if (dialogueLines != null && dialogueLines.Count > 0)
        {
            typingCoroutine = StartCoroutine(typeDialog(dialogueLines[currentLineIndex]));
        }
        //StartCoroutine(typeDialog("¿Que sentido tiene vivir una vida sin un proposito?"));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                // Skip to the end of the current line
                StopCoroutine(typingCoroutine);
                dialogueText.text = dialogueLines[currentLineIndex];
                isTyping = false;
            }
            else
            {
                currentLineIndex++;
                if (currentLineIndex < dialogueLines.Count)
                {
                    typingCoroutine = StartCoroutine(typeDialog(dialogueLines[currentLineIndex]));
                }
                else
                {

                    sceneController.loadScene("TopDown");
                }
            }
        }
    }

    public IEnumerator typeDialog(string dialog)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f/letterPerSeconds);
        }
        isTyping = false;
    }

   


}
