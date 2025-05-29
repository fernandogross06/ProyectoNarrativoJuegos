using UnityEngine;

public class InvisibleTile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {

            if (collision.gameObject.CompareTag("InvisibleTile"))
            {
                SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
                Color currentColor = spriteRenderer.color;

                spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
                  
            }
            
        }
    }
}
