using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOver;
    public GameObject feedback;

    public GameObject pause;
    public bool isPause;

    public float incremento;

    public GameObject jogador;

    public bool acertou;
    
    public int totalScore;
    public Text scoreText;
    public int frutasVivas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        instance = this;
        frutasVivas = 5;
        
    }

    void Update () {
        if (Input.GetKeyDown (KeyCode.P)) 
        {
            isPause = !isPause;

            if (isPause) {
                Pause ();
            }
            else
            {
                UnPause();
            }
        }
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame(string lvlName)
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(lvlName);
    }

    public void Errou(GameObject fruta)
    {
        acertou=false;
        Debug.Log("errou a pergunta");
        Time.timeScale = 1;
        Destroy(fruta, 3f);
        Debug.Log("errou");
        frutasVivas--;
    }

    public void Retorno(GameObject feedback)
    {
        feedback.SetActive(true);
        Destroy(feedback, 3f);
    }

    public void Acertou(GameObject fruta)
    {
        acertou=true;
        Debug.Log("acertou a pergunta");
        Destroy(fruta, 0.1f);
        Time.timeScale = 1;
        totalScore += Fruits.instance.Score;
        scoreText.text = totalScore.ToString();
        frutasVivas--;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

}
 