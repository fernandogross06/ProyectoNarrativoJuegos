using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Image imageDisplay; // Imagen de fondo
    [SerializeField] private Image arrowImage;   // Flecha que se moverá
    [SerializeField] private float arrowMoveDistance = 20f;
    [SerializeField] private float arrowMoveSpeed = 1f;

    [SerializeField] private List<string> dialogueLines;
    [SerializeField] private List<Sprite> dialogueSprites;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float timeBetweenLines = 0.5f;
    public string sceneName;

    public SceneController sceneController;

    private int currentLineIndex = 0;
    private Coroutine fadeCoroutine;
    private bool isFading = false;

    private Vector3 arrowStartPos;

    void Start()
    {
        dialogueText.alpha = 0f;
        SetImageAlpha(imageDisplay, 0f);
        imageDisplay.sprite = null;

        if (arrowImage != null)
        {
            arrowStartPos = arrowImage.rectTransform.anchoredPosition;
            StartCoroutine(AnimateArrow());
        }

        if (dialogueLines != null && dialogueLines.Count > 0)
        {
            fadeCoroutine = StartCoroutine(ShowLine(currentLineIndex));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isFading) return;

            currentLineIndex++;

            if (currentLineIndex < dialogueLines.Count)
            {
                fadeCoroutine = StartCoroutine(ShowLine(currentLineIndex));
            }
            else
            {
                sceneController.loadScene(sceneName);
            }
        }
    }

    private IEnumerator ShowLine(int index)
    {
        isFading = true;

        yield return StartCoroutine(FadeText(0f, fadeDuration));
        yield return StartCoroutine(FadeImage(imageDisplay, 0f, fadeDuration));
        yield return new WaitForSeconds(timeBetweenLines);

        dialogueText.text = dialogueLines[index];

        if (index < dialogueSprites.Count && dialogueSprites[index] != null)
        {
            imageDisplay.sprite = dialogueSprites[index];
        }
        else
        {
            imageDisplay.sprite = null;
        }

        yield return StartCoroutine(FadeText(1f, fadeDuration));

        if (imageDisplay.sprite != null)
        {
            yield return StartCoroutine(FadeImage(imageDisplay, 1f, fadeDuration));
        }

        isFading = false;
    }

    private IEnumerator FadeText(float targetAlpha, float duration)
    {
        float startAlpha = dialogueText.alpha;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            dialogueText.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        dialogueText.alpha = targetAlpha;
    }

    private IEnumerator FadeImage(Image image, float targetAlpha, float duration)
    {
        float startAlpha = image.color.a;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / duration);
            SetImageAlpha(image, newAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        SetImageAlpha(image, targetAlpha);
    }

    private void SetImageAlpha(Image image, float alpha)
    {
        if (image == null) return;
        var color = image.color;
        color.a = alpha;
        image.color = color;
    }

    private IEnumerator AnimateArrow()
    {
        while (true)
        {
            float elapsed = 0f;
            Vector3 start = arrowStartPos;
            Vector3 end = arrowStartPos + Vector3.right * arrowMoveDistance;

           
            while (elapsed < 1f)
            {
                arrowImage.rectTransform.anchoredPosition = Vector3.Lerp(start, end, elapsed);
                elapsed += Time.deltaTime * arrowMoveSpeed;
                yield return null;
            }

          
            elapsed = 0f;
            while (elapsed < 1f)
            {
                arrowImage.rectTransform.anchoredPosition = Vector3.Lerp(end, start, elapsed);
                elapsed += Time.deltaTime * arrowMoveSpeed;
                yield return null;
            }
        }
    }
}
