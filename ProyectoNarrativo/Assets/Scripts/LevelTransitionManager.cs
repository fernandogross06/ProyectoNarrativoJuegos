using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelTransitionManager : MonoBehaviour

{
    public GameObject[] levels;
    public GameObject player;
    public string[] level_names;
    public GameObject spawn_far;
    public GameObject spawn_mountain;
    public static LevelTransitionManager Instance { get; private set; }


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLevels(string level_name)
    {
        //string level_name = names[level];
        GameObject spawn = spawn_far;
        foreach (GameObject item in levels)
        {
            item.SetActive(false);
        }


        foreach (GameObject item in levels)
        {
            if(item.CompareTag(level_name)){
                item.SetActive(true);

                if (level_name == "cave_far")
                {
                    spawn = spawn_far;
                    player.transform.localScale = new Vector3(0.2f, 0.1f, 0.1f);
                }
                if (level_name == "cave_mountain")
                {
                    spawn = spawn_mountain;
                    player.transform.localScale = Vector3.one;
                }
                player.gameObject.transform.position = spawn.gameObject.transform.position;
            }
            
        }

    }
}
