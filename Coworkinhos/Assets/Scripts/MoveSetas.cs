using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSetas : MonoBehaviour
{
    public float velocidade;
    public float forcaPulo;

    private Rigidbody2D rigidbody;
    private Animator ani;

    public bool pulando;
    public bool pulouDuasVezes;

    public int dist;

    public Transform porta1;
    public Transform porta2;
    public Transform perso1;
    public Transform perso2;

    public GameObject setadorLvl;

    public string lvl;

    public GameObject gc;

    public int frutas;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(velocidade <= 0.0f)
        {
            velocidade = 0.5f;
        }
        Movimento();
        Pulo();
        InteractPorta();
    }

    void Movimento()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal2"),0f,0f);
        transform.position += movimento * Time.deltaTime * velocidade;
        if(Input.GetAxis("Horizontal2") >0f)
        {
            ani.SetBool("Andando",true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if(Input.GetAxis("Horizontal2") <0f)
        {
            ani.SetBool("Andando",true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        if(Input.GetAxis("Horizontal2") ==0f)
        {
            ani.SetBool("Andando",false);
        }
    }
    void Pulo()
    {
        if(Input.GetButtonDown("Jump2"))
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

        if(colisao.gameObject.layer==6 || colisao.gameObject.layer==8 || colisao.gameObject.tag=="Player1")
        {
            pulando = false;
            ani.SetBool("Pulando",false);
        }

         if(colisao.gameObject.layer == 7)
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }
     void OnCollisionExit2D(Collision2D colisao)
    {
        if(colisao.gameObject.layer==6 || colisao.gameObject.layer==8 || colisao.gameObject.tag=="Player1")
        {
            pulando=true;
        }
    }

    void InteractPorta ()
    {
        frutas = gc.GetComponent<GameController>().frutasVivas;
        
        if (Input.GetKeyDown("s") && Vector3.Distance(perso1.position,porta1.position)<dist && Vector3.Distance(perso2.position,porta2.position)<dist && frutas<=0 )
        {
            setadorLvl.GetComponent<SetarLvl>().Setar();
            GameController.instance.RestartGame(lvl);
        }
    }
}
