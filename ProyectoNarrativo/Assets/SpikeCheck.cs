using System.Collections;
using UnityEngine;

public class SpikeCheck : MonoBehaviour
{
    bool isDeath;
    RespawnPlayer respawn;
    Animator animator;
    PlayerMovement movement;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        respawn = GetComponent<RespawnPlayer>();
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        isDeath = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Debug.Log("Toqué algo");
        
            if(!isDeath) { 
                if (collision.gameObject.CompareTag("Spikes"))
                {
                    //respawnPlayer.spawnPoint = respawnPoint;
                    isDeath = true;
                    StartCoroutine(DeathSequence());
                }
            }
        }
    }


    IEnumerator DeathSequence()
    {
        print(Time.time);
        animator.SetBool("IsDeath", true);
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsSliding", false);
        movement.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(1);
        animator.SetBool("IsDeath", false);
        isDeath = false;
        movement.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        respawn.PlayerDeath();
    }
}
