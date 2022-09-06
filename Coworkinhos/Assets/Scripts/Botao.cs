using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    // Start is called before the first frame update
    public bool pisou;

    public GameObject plataforma;

    public float velocidade;
    public Transform posicaoAtual;
    public Transform[] pontos;

    public int pontoSelecao;

    void Start()
    {
        posicaoAtual = pontos[pontoSelecao];
    }

    // Update is called once per frame
    void Update()
    {
        if(pisou==true)
        {
            Mover();
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {

        if(colisao.gameObject.tag == "Player1" || colisao.gameObject.tag == "Player2")
        {
            pisou =true;
            //Debug.Log("pisou botao");
        }
    }
    void OnCollisionExit2D(Collision2D colisao)
    {

        if(colisao.gameObject.tag == "Player1" || colisao.gameObject.tag == "Player2")
        {
            pisou =false;
            //Debug.Log("pisou botao");
        }
    }

    void Mover()
    {
        //Debug.Log("movendo");
        plataforma.transform.position = Vector2.MoveTowards(plataforma.transform.position,posicaoAtual.position,Time.deltaTime*velocidade);

       if(plataforma.transform.position.y == pontos[pontoSelecao].transform.position.y)
       {
        pontoSelecao++;
        if(pontoSelecao==pontos.Length)
        {
            pontoSelecao=0;
        }
        posicaoAtual=pontos[pontoSelecao];
       }
    }

}
