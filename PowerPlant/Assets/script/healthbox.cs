using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbox : MonoBehaviour
{
    private HealthManager healthManager;
    public AudioClip _audioClip;

    void Start()
    {
        // Find and assign the HealthManager in the scene
        healthManager = FindObjectOfType<HealthManager>();
        
        if (healthManager == null)
        {
            Debug.LogError("HealthManager not found in the scene!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Player"))
         {
            Debug.Log("health+");
            Destroy(gameObject); 
            healthManager.Heal(20);
            AudioSource.PlayClipAtPoint(_audioClip, transform.position);
         }

    }
}
