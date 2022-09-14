using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{

    private CapsuleCollider2D capsula;
    private CircleCollider2D circulo;

    public GameObject melanciaQuestion;
    public GameObject laranjaQuestion;

   

    // Start is called before the first frame update
    void Start()
    {
        capsula = GetComponent<CapsuleCollider2D>();
        circulo = GetComponent<CircleCollider2D>();
        //objeto = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player1")
        {
            if(gameObject.tag == "Watermelon"){
                Debug.Log("passar reto");
            }
            else{
                Time.timeScale = 0;
                laranjaQuestion.SetActive(true);
                Destroy(laranjaQuestion, 5f);
                Destroy(gameObject);
            }
        }
           

        if(collider.gameObject.tag == "Player2")
        {
             if(gameObject.tag == "Orange"){
                Debug.Log("passar reto");
            }
            else{
                Time.timeScale = 0;
                melanciaQuestion.SetActive(true);
                Destroy(melanciaQuestion, 5f);
                Destroy(gameObject);
            }
        }
    }
}
