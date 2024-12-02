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

    public void Morrer()
    {
        if (estaVivo)
        {
            estaVivo = false; 

            if (audioSourceMorte != null && somMorte != null)
            {
                audioSourceMorte.clip = somMorte;
                audioSourceMorte.Play();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            Morrer(); 
        }
    }
}
