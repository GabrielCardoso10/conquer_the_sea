using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisao : MonoBehaviour
{
    [SerializeField] private GameObject painelGameOver; 
    [SerializeField] private AudioSource audioSourceMorte; 
    [SerializeField] private AudioClip somMorte; 
    [SerializeField] private float tempoBonus = 5f; 
    private bool bonusAtivo = false;
    private int multiplicador = 1; 

    void Start()
    {
        
        painelGameOver.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "inimigo" || collision.gameObject.tag == "limite")
        {
            GameOver();
        }
        else if (collision.gameObject.tag == "2x")
        {
            
            StartCoroutine(AtivarBonus2x());
            Destroy(collision.gameObject); 
        }
    }

    private void GameOver()
    {
       
        Time.timeScale = 0;

        
        if (audioSourceMorte != null && somMorte != null)
        {
            audioSourceMorte.clip = somMorte;
            audioSourceMorte.Play();
        }

       
        StartCoroutine(ExibirPainelGameOver());
    }

    private IEnumerator ExibirPainelGameOver()
    {
        
        yield return new WaitForSecondsRealtime(1f);
     
        painelGameOver.SetActive(true);
    }

    private IEnumerator AtivarBonus2x()
    {
        bonusAtivo = true;
        multiplicador = 2; 
        yield return new WaitForSeconds(tempoBonus); 
        multiplicador = 1; 
        bonusAtivo = false;
    }

   
    public void AdicionarPontos(int pontos)
    {
        
        int pontosComBonus = pontos * multiplicador;
        Debug.Log("Pontos adicionados: " + pontosComBonus);
    }
}
