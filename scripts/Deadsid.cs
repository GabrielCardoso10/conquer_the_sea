using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePersonagem : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceMorte; // O componente AudioSource para o som de morte
    [SerializeField] private AudioClip somMorte;           // O áudio que será reproduzido ao morrer

    private bool estaVivo = true; // Variável para controlar o estado de vida do personagem

    void Start()
    {
        // Inicialmente, o personagem está vivo
        estaVivo = true;
    }

    // Método que será chamado quando o personagem morrer
    public void Morrer()
    {
        if (estaVivo) // Verifica se o personagem ainda está vivo
        {
            estaVivo = false; // Define como morto

            // Reproduz o som de morte
            if (audioSourceMorte != null && somMorte != null)
            {
                audioSourceMorte.clip = somMorte;
                audioSourceMorte.Play();
            }

            // Aqui você pode adicionar outras lógicas para quando o personagem morrer
            // Ex: desativar controles, exibir tela de game over, etc.
        }
    }

    // Método que detecta colisões
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            Morrer(); // Chama o método Morrer quando colidir com um inimigo
        }
    }
}
