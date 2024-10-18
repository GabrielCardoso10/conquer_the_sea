using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomAoClicar : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; 

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0)) 
        {
            
            if (audioSource != null && !audioSource.isPlaying) 
            {
                audioSource.Play();
            }
        }
    }
}
