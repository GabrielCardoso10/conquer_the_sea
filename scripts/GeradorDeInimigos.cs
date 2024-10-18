using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeInimigos : MonoBehaviour
{
    [SerializeField] private PesoInimigo[] inimigos;
    [SerializeField] private GameObject bonus2x; 
    private int totalPesos;
    private float intervaloGeracao = 4f;  
    private float tempoDecorrido = 0f;    
    private float dificuldadeEscala = 0.1f;  
    private float chanceDeGerarBonus = 0.1f; 

    void Start()
    {
      
        foreach (PesoInimigo i in inimigos)
        {
            totalPesos += i.peso;
        }

      
        StartCoroutine(GerarInimigos());
    }

    private IEnumerator GerarInimigos()
    {
        while (true)
        {
            int quantidadeDeInimigos = Random.Range(1, 4);  

            for (int i = 0; i < quantidadeDeInimigos; i++)
            {
                
                Instantiate(
                    GetInimigo(), 
                    new Vector3(Random.Range(3.5f, 7.5f), Random.Range(-4.5f, 4.5f), 0), 
                    Quaternion.identity
                );
            }

            
            if (Random.value < chanceDeGerarBonus)
            {
                Instantiate(bonus2x, new Vector3(Random.Range(3.5f, 7.5f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
            }

           
            yield return new WaitForSeconds(intervaloGeracao);

           
            intervaloGeracao *= dificuldadeEscala;
            intervaloGeracao = Mathf.Clamp(intervaloGeracao, 0.5f, 3f);  
        }
    }

    private GameObject GetInimigo()
    {
        int numeroSorteado = Random.Range(0, totalPesos) + 1;
        int pesoProcessado = 0;

        for (int i = 0; i < inimigos.Length; i++)
        {
            pesoProcessado += inimigos[i].peso;

            if (numeroSorteado <= pesoProcessado)
            {
                return inimigos[i].inimigo;
            }
        }
        return null; 
    }
}
