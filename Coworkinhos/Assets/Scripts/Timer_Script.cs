using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Script : MonoBehaviour
{
    // Start is called before the first frame update

    public Text timeTxt;
    private float tempo;
    public float tempoInicial;

    void Start()
    {
        tempo = tempoInicial;
    }

    // Update is called once per frame
    void Update()
    {
        tempo = tempo-Time.deltaTime;
        timeTxt.text = tempo.ToString("F0");
        if(tempo <=0)
        {
            GameController.instance.ShowGameOver();
        }
    }
}
