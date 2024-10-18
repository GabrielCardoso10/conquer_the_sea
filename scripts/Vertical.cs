using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertical : MonoBehaviour
{
    [SerializeField][Range(0,2)]private float velocidade;

    private enum Direcao{SUBIR,DESCER};

    private Direcao DirecaoAtual = Direcao.SUBIR;

    void Start()
    {
        
        int DirecaoInicial = Random.Range(0,2);

        if (DirecaoInicial == 0)
        {

            DirecaoAtual = Direcao.SUBIR;

        }
        else{

            DirecaoAtual = Direcao.DESCER;
        
        }

    }

    
    void Update()
    {

        switch (DirecaoAtual)
        {
            case Direcao.SUBIR:

            transform.position += new Vector3(0, velocidade * Time.deltaTime, 0);

            if (transform.position.y >=6 )
            {
                DirecaoAtual = Direcao.DESCER;
            }

            break;

            case Direcao.DESCER:

            transform.position -= new Vector3(0, velocidade * Time.deltaTime, 0);

            if (transform.position.y <= -6)
            {
                
                DirecaoAtual = Direcao.SUBIR;

            }
            break;

            
        }

    }
}
