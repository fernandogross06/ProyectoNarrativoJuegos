using System.Collections;
using UnityEngine;

public class TriggerOutro : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement player;
    public SceneController sceneController;
    public Rigidbody2D playerBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {

            if (collision.CompareTag("Player"))
            {

                StartCoroutine(WinSequence());

            }
        }
    }


    IEnumerator WinSequence()
    {
       
        animator.SetBool("IsDeath", true);
        playerBody.bodyType = RigidbodyType2D.Static;
        player.enabled = false;
        
        yield return new WaitForSeconds(2);
        sceneController.loadScene("GameOutro");

    }

}
