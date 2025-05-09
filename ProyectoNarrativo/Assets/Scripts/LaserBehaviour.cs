using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
   
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public GameObject startVFX;
    public GameObject endVFX;
    private List<ParticleSystem> particles = new List<ParticleSystem>();

    void Start()
    {
        fillLists();
        disableLaser();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            enableLaser();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            updateLaser();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            disableLaser();
        }
    }

    void enableLaser()
    {
        lineRenderer.enabled = true;

        for(int i = 0; i<particles.Count; i++)
        {
            particles[i].Play();
        }
    }

    void updateLaser()
    {
        var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        
        lineRenderer.SetPosition(0, (Vector2)firePoint.position);
        startVFX.transform.position = (Vector2)firePoint.position;
        lineRenderer.SetPosition(1, mousePos);
        
        endVFX.transform.position = lineRenderer.GetPosition(1);

        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // Asegura que esté en el plano 2D

        foreach (Transform child in startVFX.transform)
        {
            Vector3 direction = mouseWorldPos - child.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            child.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    void disableLaser()
    {
        lineRenderer.enabled = false;
        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].Stop();
        }
    }

    void fillLists()
    {
        for(int i = 0; i<startVFX.transform.childCount; i++)
        {
            var ps = startVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps != null)
            {
                particles.Add(ps);
            }
        }
        for (int i = 0; i < endVFX.transform.childCount; i++)
        {
            var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
            {
                particles.Add(ps);
            }
        }
    }
}
