using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    public float moveSpeed = 5f;
    public float zoomSpeed = 5f;

    private Coroutine moveCoroutine;
    private Camera cam;

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        cam = GetComponent<Camera>();
    }

    public void MoveTo(Vector3 targetPosition, float targetSize)
    {
        // Stop any ongoing movement
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(MoveCameraSmoothly(targetPosition, targetSize));
    }

    private IEnumerator MoveCameraSmoothly(Vector3 targetPos, float targetSize)
    {
        // Maintain original Z
        targetPos.z = transform.position.z;

        while (Vector3.Distance(transform.position, targetPos) > 0.01f ||
               Mathf.Abs(cam.orthographicSize - targetSize) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, zoomSpeed * Time.deltaTime);
            yield return null;
        }

        // Snap to final position and size
        transform.position = targetPos;
        cam.orthographicSize = targetSize;

        moveCoroutine = null;
    }
}
