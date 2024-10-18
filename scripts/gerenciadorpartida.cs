using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorPartida : MonoBehaviour
{
    private bool partidaIniciada;

    [SerializeField] private GameObject painelGameOver;  // Painel de Game Over
    [SerializeField] private AudioSource clickSound;     // Som ao clicar na tela
    [SerializeField] private AudioSource deathSound;     // Som ao morrer

    private void Awake()  
    {
        Time.timeScale = 0;
        Application.targetFrameRate = 60;

        // Certifique-se de que o painel de Game Over está desativado no início
        if (painelGameOver != null)
        {
            painelGameOver.SetActive(false);
        }
    }

    void Update()
    {
        if (partidaIniciada) return;

        // Verifica se o jogador clicou com o botão do mouse (ou toque na tela)
        if (Input.GetMouseButtonDown(0))
        {
            partidaIniciada = true;
            Time.timeScale = 1;

            // Reproduz o som de clique
            if (clickSound != null)
            {
                clickSound.Play();
            }
        }
    }

    public void ReiniciarPartida()
    {
        SceneManager.LoadScene(1);
    }

    // Função chamada quando o personagem morre
    public void OnPlayerDeath()
    {
        // Reproduz o som de morte
        if (deathSound != null)
        {
            deathSound.Play();
        }

        // Pausa o jogo e exibe o painel de Game Over
        Time.timeScale = 0;

        if (painelGameOver != null)
        {
            painelGameOver.SetActive(true);  // Ativa o painel de Game Over
        }
    }
}
