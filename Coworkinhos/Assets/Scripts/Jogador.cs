using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float Velocidade;
    public float forcaPulo;

    private Rigidbody2D rigidbody;

    public bool pulando;
    public bool pulouDuasVezes;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        Pulo();
    }

    void Movimento()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movimento * Time.deltaTime * Velocidade;
    }
    void Pulo()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!pulando)
            {
                rigidbody.AddForce(new Vector2(0f,forcaPulo),ForceMode2D.Impulse);
                pulouDuasVezes = true;
            }
            else
            {
                if(pulouDuasVezes)
                {
                    rigidbody.AddForce(new Vector2(0f,forcaPulo*0.9f),ForceMode2D.Impulse);
                    pulouDuasVezes = false;
                }
            }
            
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
