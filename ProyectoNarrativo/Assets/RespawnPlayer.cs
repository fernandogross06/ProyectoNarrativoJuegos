using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{

    public Transform spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = spawnPoint.position;
        }    
    }


}
