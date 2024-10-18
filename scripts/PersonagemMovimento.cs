using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemMovimento : MonoBehaviour
{
    private Rigidbody2D rb;

    // Método Awake é chamado antes do Start
    private void Awake()
    {
        // Obtém a referência ao Rigidbody2D anexado ao GameObject
        rb = GetComponent<Rigidbody2D>();

        // Verifica se o Rigidbody2D foi encontrado, caso contrário, exibe uma mensagem de erro
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D não encontrado! Adicione um Rigidbody2D ao GameObject.");
        }
    }
   
    // Método Update é chamado uma vez por quadro
    void Update()
    {
        // Verifica se o Rigidbody2D está presente e se o botão do mouse foi pressionado
        if (rb != null && Input.GetMouseButtonDown(0))
        {
            // Define a velocidade do Rigidbody2D para zero
            rb.velocity = Vector2.zero;

            // Aplica uma força para mover o personagem para cima
            rb.AddForce(Vector2.up * 150);
        }
    }
}
