using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueBehaviour : MonoBehaviour
{
    [SerializeField] int letterPerSeconds;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] List<string> dialogueLines;

    private int currentLineIndex = 0;
    private Coroutine typingCoroutine;
    private bool isTyping = false;

    public GameObject dialogGameObject;
    
    void Start()
    {
        //if (dialogueLines != null && dialogueLines.Count > 0)
        //{
        //    typingCoroutine = StartCoroutine(typeDialog(dialogueLines[currentLineIndex]));
        //}
        Debug.Log("Start method");
        dialogGameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Pressed");
            if (isTyping)
            {
                // Terminar línea inmediatamente
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
                    // Fin del diálogo: desactiva el objeto padre
                    Transform padre = transform.parent;
                    if (padre != null)
                    {
                        padre.gameObject.SetActive(false);
                    }
                    else
                    {
                        gameObject.SetActive(false); // Por si no tiene padre
                    }
                }
            }
        }
    }

    public void StartDialog()
    {
        Debug.Log("calling StartDialog");
        dialogGameObject.SetActive(true);
        if (dialogueLines != null && dialogueLines.Count > 0)
        {
            typingCoroutine = StartCoroutine(typeDialog(dialogueLines[currentLineIndex]));
        }

        return;

    }

    public IEnumerator typeDialog(string dialog)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSeconds);
        }
        isTyping = false;
    }
}
