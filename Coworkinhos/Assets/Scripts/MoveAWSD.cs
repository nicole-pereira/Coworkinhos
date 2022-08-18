using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAWSD : MonoBehaviour
{
    public float Speed;

    float MovimentoX;
    float MovimentoY;

    Rigidbody2D rb;

    public float forcaPulo;
    public bool pulando;
    public bool pulouDuasVezes;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MovimentoX = 0;
        MovimentoY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(MovimentoX * Speed * Time.deltaTime, MovimentoY * Speed * Time.deltaTime);   
    
        if (Input.GetKeyDown(KeyCode.W))
        {
             if (Input.GetKeyDown(KeyCode.W))
            {
                if(!pulando)
                {
                    rb.AddForce(new Vector2(0f,forcaPulo),ForceMode2D.Impulse);
                    pulouDuasVezes = true;
                }
                else
                {
                    if(pulouDuasVezes)
                    {
                        rb.AddForce(new Vector2(0f,forcaPulo*0.9f),ForceMode2D.Impulse);
                        pulouDuasVezes = false;
                    }
                }
            }
        }

       if (Input.GetKeyDown(KeyCode.S))
        {
            MovimentoX = -1;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MovimentoX = -1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            MovimentoX = 1;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            MovimentoY = 0;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            MovimentoX = 0;
        }

    }

     void OnCollisionEnter2D(Collision2D colisao)
    {

        if(colisao.gameObject.layer==6)
        {
            pulando = false;
        }
    }
     void OnCollisionExit2D(Collision2D colisao)
    {
        if(colisao.gameObject.layer==6)
        {
            pulando=true;
        }
    }

}
