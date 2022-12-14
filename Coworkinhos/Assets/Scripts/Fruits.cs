using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public static Fruits instance;

    private CapsuleCollider2D capsula;
    private CircleCollider2D circulo;

    public GameObject melanciaQuestion;
    public GameObject laranjaQuestion;

    public int Score;

    public int frutasSobrando;

    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        frutasSobrando = PlayerPrefs.GetInt("Sobrando", 5);
        PlayerPrefs.SetInt("Sobrando",5);
        capsula = GetComponent<CapsuleCollider2D>();
        circulo = GetComponent<CircleCollider2D>();
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
                Destroy(gameObject);
            }
        }
    }
    void OnDestroy(){
        
        PlayerPrefs.SetInt("Sobrando", (PlayerPrefs.GetInt("Sobrando")-1));
        frutasSobrando = PlayerPrefs.GetInt("Sobrando");
        Debug.Log("tem :"+frutasSobrando+"frutas sobrando");
    }
}
