using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemMovimento : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D não encontrado! Adicione um Rigidbody2D ao GameObject.");
        }
    }
   

    void Update()
    {
        if (rb != null && Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;

            rb.AddForce(Vector2.up * 150);
        }
    }
}
