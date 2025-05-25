using UnityEngine;

public class ChangeZoneCamera : MonoBehaviour
{
    public Transform targetPosition;
    public float targetSize = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraManager.Instance.MoveTo(targetPosition.position, targetSize);
        }
    }
}
