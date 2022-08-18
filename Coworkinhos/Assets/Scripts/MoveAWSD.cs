using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAWSD : MonoBehaviour
{
    public float Velocidade;
    public float forcaPulo;

    private Rigidbody2D rigidbody;
    private Animator ani;

    public bool pulando;
    public bool pulouDuasVezes;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
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
        if(Input.GetAxis("Horizontal") >0f)
        {
            ani.SetBool("Andando",true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if(Input.GetAxis("Horizontal") <0f)
        {
            ani.SetBool("Andando",true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        if(Input.GetAxis("Horizontal") ==0f)
        {
            ani.SetBool("Andando",false);
        }
    }
    void Pulo()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!pulando)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x,forcaPulo);
                pulouDuasVezes = true;
                ani.SetBool("Pulando",true);
            }
            else
            {
                if(pulouDuasVezes)
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x,forcaPulo*0.8f);
                    pulouDuasVezes = false;
                    ani.SetBool("Pulando",true);
                }
            }
            
        }
        
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {

        if(colisao.gameObject.layer==6)
        {
            pulando = false;
            ani.SetBool("Pulando",false);
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