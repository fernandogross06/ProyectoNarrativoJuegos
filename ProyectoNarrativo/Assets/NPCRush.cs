using System.Collections;
using UnityEngine;

public class NPCRush : MonoBehaviour
{
    public Vector3 characterBasePosition;
    public Transform player;                // Assign in Inspector
    public PlayerMovement playerMovement; 
    public Transform secondaryTarget;                // Assign in Inspector
    public float rushDuration = 0.5f;
    public float overshootDistance = 2f;    // Distance past the player
    public float overshootDuration = 0.3f;

    private bool hasRushed = false;
    public SpriteRenderer caciqueOriginal;

    public void Start()
    {
        characterBasePosition = transform.position;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

            StartRush();
        }
    }
    public void StartRush()
    {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            caciqueOriginal.enabled = false;
            hasRushed = true;
            //playerMovement.IsInputEnabled = false;
            StartCoroutine(RushAndOvershoot());

    }

    IEnumerator RushAndOvershoot()
    {
        // Phase 1: Rush to player
        Vector3 startPos = transform.position;
        Vector3 playerPos = player.position;
        float elapsed = 0f;

        while (elapsed < rushDuration)
        {
            transform.position = Vector3.Lerp(startPos, playerPos, elapsed / rushDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = playerPos;

        // Optional: Trigger camera shake, animation, player knockback here

        // Phase 2: Continue past the player
        
        elapsed = 0f;

        startPos = transform.position;
        Vector3 pos = secondaryTarget.position;
        while (elapsed < overshootDuration)
        {
            transform.position = Vector3.Lerp(startPos, pos, elapsed / overshootDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = characterBasePosition;

        GetComponent<SpriteRenderer>().enabled = false;
        caciqueOriginal.enabled = true;
        // Done — you can trigger the next cutscene step here
    }
}
