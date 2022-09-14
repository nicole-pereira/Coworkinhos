using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onus_Bonus : MonoBehaviour
{

     public GameObject gc;

    public GameObject jogador;

    public float incremento;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        if(gc.GetComponent<GameController>().acertou==true)
        {
            Debug.Log("acertou");
            if(jogador.tag=="Player1"){
                jogador.GetComponent<MoveAWSD>().Velocidade+=incremento;
            }
            else if(jogador.tag=="Player2"){
                jogador.GetComponent<MoveSetas>().Velocidade+=incremento;
            }
            
        }
        else if (gc.GetComponent<GameController>().acertou==false)
        {
            Debug.Log("errou");
            if(jogador.tag=="Player1"){
                jogador.GetComponent<MoveAWSD>().Velocidade-=incremento;
            }
            else if(jogador.tag=="Player2"){
                jogador.GetComponent<MoveSetas>().Velocidade-=incremento;
            }
        }
    }
}
