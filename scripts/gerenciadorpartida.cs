using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorPartida : MonoBehaviour
{
    private bool partidaIniciada;

    [SerializeField] private GameObject painelGameOver;
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private AudioSource deathSound;

    private void Awake()  
    {
        Time.timeScale = 0;
        Application.targetFrameRate = 60;

        if (painelGameOver != null)
        {
            painelGameOver.SetActive(false);
        }
    }

    void Update()
    {
        if (partidaIniciada) return;

        if (Input.GetMouseButtonDown(0))
        {
            partidaIniciada = true;
            Time.timeScale = 1;

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

    public void OnPlayerDeath()
    {
        if (deathSound != null)
        {
            deathSound.Play();
        }

        Time.timeScale = 0;

        if (painelGameOver != null)
        {
            painelGameOver.SetActive(true); 
        }
    }
}
