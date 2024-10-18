using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDoJogo;
    [SerializeField] private GameObject PainelMenuInicial;
    [SerializeField] private GameObject PainelOpcoes;
    [SerializeField] private AudioSource musicaDeFundo; 
    private void Start()
    {
        PainelMenuInicial.SetActive(true);
        PainelOpcoes.SetActive(false);
    }

    public void Jogar()
    {
     
        if (musicaDeFundo != null)
        {
            musicaDeFundo.Stop();
            Debug.Log("Música parada.");
        }
        else
        {
            Debug.Log("AudioSource não encontrado.");
        }

        
        SceneManager.LoadScene(nomeDoLevelDoJogo);
    }

    public void AbrirOpcoes()
    {
        PainelMenuInicial.SetActive(false);
        PainelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        PainelMenuInicial.SetActive(true);
        PainelOpcoes.SetActive(false);
    }

    public void SairJogo()
    {
        Debug.Log("sair do jogo");
        Application.Quit();
    }
}
