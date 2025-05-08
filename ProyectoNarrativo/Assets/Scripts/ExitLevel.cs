using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    public string current_level_name;
    public string next_level_name;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
                LevelTransitionManager.Instance.ChangeLevels(next_level_name);
            }
        }
    }
}
